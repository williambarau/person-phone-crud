using Microsoft.EntityFrameworkCore;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Reflection;

namespace Examples.Charge.Infra.Data.Context
{
    public class PGCContext : DbContext
    {
        public static bool firstRun = true;

        public PGCContext(DbContextOptions<PGCContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PGCContext)));
        }
        
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonPhone> PersonPhone { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }
    }
}