using System.ComponentModel.DataAnnotations;

namespace LinksManager.DAL.Entities
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
