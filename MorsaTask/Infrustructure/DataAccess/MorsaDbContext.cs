using Infrustructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.DataAccess
{
    public class MorsaDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public MorsaDbContext(DbContextOptions options) : base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

        }
    }
    public class MorsaDbContextCoffeeFactory : IDesignTimeDbContextFactory<MorsaDbContext>
    {
        public MorsaDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<MorsaDbContext>();
            optionBuilder.UseSqlServer(@"Data Source=SAEEDEH-LEGION;Initial Catalog=Morsa;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new MorsaDbContext(optionBuilder.Options);
        }
    }
}
