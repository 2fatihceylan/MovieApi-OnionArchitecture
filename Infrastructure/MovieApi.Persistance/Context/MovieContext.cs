using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Persistance.Context
{
    public class MovieContext : IdentityDbContext<AppUser>
    {



        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Series> Serieses { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("");
        }





    }
}
