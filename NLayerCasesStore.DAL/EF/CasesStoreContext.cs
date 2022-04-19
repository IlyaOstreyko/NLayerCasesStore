using Microsoft.EntityFrameworkCore;
using NLayerCasesStore.DAL.Entities;

namespace NLayerCasesStore.DAL.EF
{
    public class CasesStoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<User> Users { get; set; }

        public CasesStoreContext(DbContextOptions<CasesStoreContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Basket>()
                .HasMany(c => c.Cases)
                .WithMany(s => s.Baskets)
                .UsingEntity<BasketCase>(
                   j => j
                    .HasOne(pt => pt.Case)
                    .WithMany(t => t.BasketsCases)
                    .HasForeignKey(pt => pt.CaseId),
                j => j
                    .HasOne(pt => pt.Basket)
                    .WithMany(p => p.BasketsCases)
                    .HasForeignKey(pt => pt.BasketId),
                j =>
                {
                    j.Property(pt => pt.NumberPairBasketCase).HasDefaultValue(1);
                    j.HasKey(t => new { t.BasketId, t.CaseId });
                    j.ToTable("BasketsCases");
                });
        }
        //static CasesStoreContext()
        //{
        //    Database.SetInitializer<CasesStoreContext>(new StoreDbInitializer());
        //}
        //public CasesStoreContext(string connectionString)
        //    : base(connectionString)
        //{
        //}
    }

    //public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CasesStoreContext>
    //{
    //    protected void Seed(CasesStoreContext db)
    //    {
    //        db.Cases.Add(new Case
    //        {
    //            Model = "iPhone X",
    //            Company = "Apple",
    //            Color = "Green",
    //            Price = 15
    //        });
    //        db.Cases.Add(new Case
    //        {
    //            Model = "iPhone 5",
    //            Company = "Apple",
    //            Color = "Green",
    //            Price = 16
    //        });
    //        db.Cases.Add(new Case
    //        {
    //            Model = "iPhone 6",
    //            Company = "Apple",
    //            Color = "Green",
    //            Price = 14
    //        });
    //        db.Cases.Add(new Case
    //        {
    //            Model = "iPhone XS Pro Max",
    //            Company = "Apple",
    //            Color = "Green",
    //            Price = 13
    //        });
    //        db.SaveChanges();
    //    }
    //}
}
