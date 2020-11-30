using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Context
{
    public class AppContext : DbContext
    {
        public DbSet<ProfileModel> AccountProfileModel { get; set; }
        public DbSet<PostComentaryModel> PostComentaryModel { get; set; }
        public DbSet<PostModel> PostModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileModel>().HasMany(m => m.ProfileFollowing).WithMany();
            modelBuilder.Entity<PostModel>().HasMany(m => m.PostComentaries).WithMany();
        }
    }
}