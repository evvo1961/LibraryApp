using Microsoft.EntityFrameworkCore;
using LibraryAppApi.Models;

namespace LibraryAppApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            var created = this.Database.EnsureCreated();

            if (created)
            {
                Books.Add(new Book { Title = "Dracula", Author = "Bram Stoker", PublicationDate = DateTime.Now, EditionNumber = 1, ISBN = "123456" });                

                SaveChanges();
            }
        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
