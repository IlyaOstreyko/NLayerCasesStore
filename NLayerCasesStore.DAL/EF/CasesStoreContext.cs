
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

        //public CasesStoreContext(DbContextOptions<CasesStoreContext> options)
        //    : base(options) { }
        static CasesStoreContext()
        {
            Database.SetInitializer<CasesStoreContext>(new StoreDbInitializer());
        }
        public CasesStoreContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CasesStoreContext>
    {
        protected void Seed(CasesStoreContext db)
        {
            db.Cases.Add(new Case
            {
                Model = "iPhone X",
                Company = "Apple",
                Color = "Green",
                Price = 15
            });
            db.Cases.Add(new Case
            {
                Model = "iPhone 5",
                Company = "Apple",
                Color = "Green",
                Price = 16
            });
            db.Cases.Add(new Case
            {
                Model = "iPhone 6",
                Company = "Apple",
                Color = "Green",
                Price = 14
            });
            db.Cases.Add(new Case
            {
                Model = "iPhone XS Pro Max",
                Company = "Apple",
                Color = "Green",
                Price = 13
            });
            db.SaveChanges();
        }
    }
}
