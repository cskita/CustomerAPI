using CustomerAPI.Core.Model.City;
using CustomerAPI.Core.Model.Classification;
using CustomerAPI.Core.Model.Customer;
using CustomerAPI.Core.Model.Gender;
using CustomerAPI.Core.Model.Region;
using CustomerAPI.Core.Model.User;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<City> City { get; set; }
        public DbSet<Classification> Classification { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<UserSys> UserSys { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
