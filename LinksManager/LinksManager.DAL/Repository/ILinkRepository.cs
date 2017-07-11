using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinksManager.DAL.Entities;

namespace LinksManager.DAL.Repository
{
    public interface ILinkRepository : IDisposable
    {
        IEnumerable<Link> GetLinks();

        Task<Link> GetLinkByIdAsync(int linkId);

        Task<int> InsertLinkAsync(Link link);

        Task<int> DeleteLinkAsync(int linkId);

        Task<int> UpdateLinkAsync(Link link);

        IEnumerable<Category> GetCategories();
    }
}
