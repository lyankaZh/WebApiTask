using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinksManager.DAL.Entities;

namespace LinksManager.DAL.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private readonly LinksContext _context;
        private bool _disposed;

        public LinkRepository(LinksContext context)
        {
            _context = context;
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Link> GetLinks()
        {
            return _context.Links;
        }

        public async Task<Link> GetLinkByIdAsync(int linkId)
        {
            return await _context.Links.FindAsync(linkId);
        }

        public async Task<int> InsertLinkAsync(Link link)
        {
            _context.Links.Add(link);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteLinkAsync(int linkId)
        {
            var linkToDelete = await _context.Links.FindAsync(linkId);
            if (linkToDelete != null)
            {
                _context.Links.Remove(linkToDelete);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateLinkAsync(Link link)
        {
            var linkToUpdate = await _context.Links.FindAsync(link.Id);
            if (linkToUpdate != null)
            {
                linkToUpdate.Category = link.Category;
                linkToUpdate.Description = link.Description;
                linkToUpdate.Url = link.Url;
            }

            return await _context.SaveChangesAsync();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}
