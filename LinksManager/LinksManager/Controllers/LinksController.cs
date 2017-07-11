using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using LinksManager.DAL.Entities;
using LinksManager.DAL.Repository;

namespace LinksManager.Controllers
{
    public class LinksController : ApiController
    {
        private readonly ILinkRepository _repository;

        public LinksController(ILinkRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Link> GetLinks()
        {
            return _repository.GetLinks();
        }

        public async Task<IHttpActionResult> GetLink(int id)
        {
            var link = await _repository.GetLinkByIdAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            return Ok(link);
        }

        public IEnumerable<Link> GetLinksByCategory(string category)
        {
            return _repository.GetLinks().Where(
                l => string.Equals(l.Category.Name, category, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IHttpActionResult> PostLink(Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.InsertLinkAsync(link);
            return Ok();
        }

        public async Task<IHttpActionResult> DeleteLink(int id)
        {
            var link = await _repository.GetLinkByIdAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            await _repository.DeleteLinkAsync(id);
            return Ok(link);
        }

        public async Task<IHttpActionResult> PutLink(int id, Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != link.Id)
            {
                return BadRequest();
            }

            if (_repository.GetLinks().Count(e => e.Id == id) > 0)
            {
                if (link.Category == null)
                {
                    link.Category = _repository.GetCategories().FirstOrDefault(x => x.Id == link.CategoryId);
                }

                await _repository.UpdateLinkAsync(link);
            }
            else
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
