using Microsoft.EntityFrameworkCore;

namespace LibraryTask_dexef.Web.Extensions
{

    /// <summary>
    /// Seeding data by ModelBuilder
    /// </summary>
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "C# Programming",
                    Author = "John Smith",
                    PublishedYear = 2022,
                    IsAvailable = true,
                    Genre = "Programming",
                },
                new Book
                {
                    Id = 2,
                    Title = "ASP.NET Core Development",
                    Author = "John Doe",
                    PublishedYear = 2020,
                    IsAvailable = true,
                    Genre = "Backend Development",
                },
                new Book
                {
                    Id = 3,
                    Title = "Entity Framework Core In Action",
                    Author = "Ryan Hipple",
                    PublishedYear = 2021,
                    IsAvailable = true,
                    Genre = "Programming",
                },
                new Book
                {
                    Id = 4,
                    Title = "Blazor WebAssembly: The Complete Guide",
                    Author = "Mark J. Price",
                    PublishedYear = 2021,
                    IsAvailable = true,
                    Genre = "Web Development",
                },
                new Book
                {
                    Id = 5,
                    Title = "Design Patterns in C#",
                    Author = "Robert C. Martin",
                    PublishedYear = 2009,
                    IsAvailable = true,
                    Genre = "Programming",
                }
            );
        }
    }
}