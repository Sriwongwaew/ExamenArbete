using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mood2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mood2.Models.History> History { get; set; }
        public DbSet<Mood2.Models.Playlist> Playlist { get; set; }
        public DbSet<Mood2.Models.EmotionData> EmotionData { get; set; }
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Models.Playlist>().HasKey(sb => new { sb.Id , sb.EmId });
    //}
}
