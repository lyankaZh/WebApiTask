using System.Data.Entity;
using LinksManager.DAL.Entities;

namespace LinksManager.DAL
{
    public class LinksContext : DbContext
    {
        public LinksContext() : base("LinksDb")
        {
            Database.SetInitializer(new LinksDbInitializer());
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Category> Categories { get; set; }

        public class LinksDbInitializer : DropCreateDatabaseIfModelChanges<LinksContext>
        {
            protected override void Seed(LinksContext context)
            {
                var videoCategory = new Category
                {
                    Id = 1,
                    Name = "Video"
                };
                var booksCategory = new Category
                {
                    Id = 2,
                    Name = "Books"
                };
                var socialNetworksCategory = new Category
                {
                    Id = 3,
                    Name = "Social networks"
                };

                context.Categories.Add(videoCategory);
                context.Categories.Add(booksCategory);
                context.Categories.Add(socialNetworksCategory);
                
                context.Links.Add(
                    new Link
                    {
                        Url = "happy_reading.com",
                        Category = booksCategory,
                        Description = "Interesting english articles"
                    });

                context.Links.Add(
                    new Link
                    {
                        Url = "youtube.com",
                        Category = videoCategory,
                        Description = "Funny videos"
                    });

                context.Links.Add(
                    new Link
                    {
                        Url = "facebook.com",
                        Category = socialNetworksCategory,
                        Description = "Most friends are here"
                    });

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}