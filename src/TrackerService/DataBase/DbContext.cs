using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrackerService.Models;

namespace TrackerService.DataBase
{
    public class TrackerContext : DbContext
    {
        /*public DbSet<Users> Users { get; set; }*/
        public DbSet<Goods> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        
        public TrackerContext(DbContextOptions<TrackerContext> options): base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSnakeCaseNamingConvention();
        
        protected override void OnModelCreating(ModelBuilder builder) 
            => builder.UseIdentityColumns();
    }
}