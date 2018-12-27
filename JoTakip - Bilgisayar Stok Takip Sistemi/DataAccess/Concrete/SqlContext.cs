using Entities.Concrete;
using System.Data.Entity;

namespace DataAccess.Concrete
{
    public class SqlContext:DbContext
    {
        public SqlContext() : base() {}

        public DbSet<Department> Departments { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WasteProduct> WasteProducts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
