using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class TravelBlogContext : DbContext
    {
        public TravelBlogContext()
        {

        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonExperience> PeopleExperiences { get; }
        public DbSet<Destination> Destinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlog;integrated security=True");
        }

        public TravelBlogContext(DbContextOptions<TravelBlogContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(builder);
            modelBuilder.Entity<PersonExperience>()
              .HasKey(t => new { t.PersonId, t.ExperienceId });

            modelBuilder.Entity<PersonExperience>()
                .HasOne(pt => pt.Person)
                .WithMany(p => p.PeopleExperiences)
                .HasForeignKey(pt => pt.PersonId);

            modelBuilder.Entity<PersonExperience>()
                .HasOne(pt => pt.Experience)
                .WithMany(t => t.PeopleExperiences)
                .HasForeignKey(pt => pt.ExperienceId);
        }
    }
}

