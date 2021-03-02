using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Infrasturcture.Data
{
    public class VideoShopDbContext : DbContext 
    {
        public DbSet<Video> Videos { get; set; }
        public VideoShopDbContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Video>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
