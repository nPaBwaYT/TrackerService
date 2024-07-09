using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using TrackerService.Dependencies;
using TrackerService.Models;

namespace TrackerService.DataBase
{
    public class TrackerContext : DbContext
    {
        /*public DbSet<Users> Users { get; set; }*/
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }


        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.UseIdentityColumns();
    }
}