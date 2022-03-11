using Microsoft.EntityFrameworkCore;
using NLayerCasesStore.DAL.Entities;

namespace NLayerCasesStore.DAL.EF
{
    public class CasesStoreContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<User> Users { get; set; }

        public CasesStoreContext(DbContextOptions<CasesStoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
