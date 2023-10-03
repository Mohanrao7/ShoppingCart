using Microsoft.EntityFrameworkCore;
using ShoppingCart.Model;

namespace ShoppingCart.Data
{
    public class ShoppingDbContext:DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options): base(options) 
        {
            
        }
        public DbSet<UserReg> userRegs { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Category>().ToTable("Category");
        //}
    }
}
