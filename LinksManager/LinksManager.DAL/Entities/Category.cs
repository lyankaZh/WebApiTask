using System.ComponentModel.DataAnnotations;

namespace LinksManager.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
