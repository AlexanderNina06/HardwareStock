using HardwareStock.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HardwareStock.Infrastructure.Persistence.Contexts
{
    public class HardwareContext : DbContext
    {
        public HardwareContext(DbContextOptions<HardwareContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region tables
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            #endregion



            //Definiendo Primary Keys
            #region Primary Keys
            modelBuilder.Entity<Product>().
                HasKey(product => product.Id);
            modelBuilder.Entity<Category>().
                HasKey(category => category.Id);
            #endregion

            //relaciones
            #region "Relationships"
            modelBuilder.Entity<Category>().
                HasMany<Product>(category => category.Products).
                WithOne(product => product.category).
                HasForeignKey(product => product.CategoryId).
                OnDelete(DeleteBehavior.Cascade);
            #endregion

            //Required
            #region "Property configuration"

            #region Products
            modelBuilder.Entity<Product>().
                Property(product => product.Name)
                .IsRequired();

            modelBuilder.Entity<Product>().
                Property(product => product.Price)
                .IsRequired();
            #endregion

            #region Category
            modelBuilder.Entity<Category>().
                Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(50);

            #endregion


            #endregion
        }
    }
}
