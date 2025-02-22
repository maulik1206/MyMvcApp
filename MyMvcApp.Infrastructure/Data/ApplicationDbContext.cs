using MyMvcApp.Domain.Entities;
using System.Data.Entity;

namespace MyMvcApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
