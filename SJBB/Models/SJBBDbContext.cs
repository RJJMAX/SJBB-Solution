using Microsoft.EntityFrameworkCore;
using SJBB.Models;

namespace SJBB.Models;
public class SJBBDbContext : DbContext
{

    public DbSet<Order> Orders { get; set; }
    public DbSet<Statue> Statues { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Miscellaneous> Miscellaneous { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Vendor> Vendors { get; set; }

    public SJBBDbContext() { }
    public SJBBDbContext(DbContextOptions<SJBBDbContext> options) : base(options) { }
    public DbSet<SJBB.Models.Orderline>? Orderline { get; set; }

}
