using Lab2ATP.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2ATP
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Element> Elements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductElements> ProductElements { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
