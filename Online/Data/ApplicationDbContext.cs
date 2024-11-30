using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online.Models;
using System.Collections.Generic;

namespace Online.Data
{
    public class ApplicationDbContext: IdentityDbContext<Users>

    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categoryes { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(e => e.cardItem).WithOne(c => c.Course).HasForeignKey(c => c.CourseId);
            modelBuilder.Entity<CardItem>().HasOne(c => c.Course).WithMany(c => c.cardItem).HasForeignKey(c => c.CourseId);
            modelBuilder.Entity<CardItem>().HasOne(c => c.ShoppingCart).WithMany(c => c.CartItems).HasForeignKey(c => c.ShoppingCartId);
            modelBuilder.Entity<ShoppingCart>().HasMany(c => c.CartItems).WithOne(c=> c.ShoppingCart).HasForeignKey(c => c.ShoppingCartId);
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }


    
}
