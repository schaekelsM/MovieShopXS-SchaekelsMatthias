using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Testing.Model
{
    public class MovieContext :DbContext
    {
        private IConfigurationRoot _config;

        public MovieContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["connectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<MovieActor>().ToTable("MovieActor");
            modelBuilder.Entity<Person>().ToTable("Person");



            modelBuilder.Entity<MovieActor>().HasKey(C => new { C.ActorID, C.MovieID });
        }
    }
}
