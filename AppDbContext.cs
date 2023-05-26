using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1
{
 
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
: base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

    }
}
