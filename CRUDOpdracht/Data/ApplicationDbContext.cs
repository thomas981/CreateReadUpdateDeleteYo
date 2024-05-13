using CRUDOpdracht.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUDOpdracht.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
