using Kino.Domain.Actor;
using Kino.Domain.Director;
using Kino.Domain.Movie;
using Kino.Domain.MovieItem;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Infrastructure
{
    public class KinoDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directros { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieItem> MovieItems { get; set; } 
        public KinoDbContext(DbContextOptions<KinoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasKey(x => x.MovieId);

            modelBuilder.Entity<Director>()
                .HasKey(x => x.DirectorId);

            modelBuilder.Entity<Actor>()
                .HasKey(x => x.ActorId);

            modelBuilder.Entity<Movie>()
                .OwnsMany(x => x.MovieVersions, a => 
                {
                    a.WithOwner().HasForeignKey(z => z.MovieId);
                    a.HasKey(z => z.MovieVersionId);
                });
            modelBuilder.Entity<Movie>()
                .OwnsMany(x => x.MovieComents, a =>
                {
                    a.WithOwner().HasForeignKey(z => z.MovieId);
                    a.HasKey(z => z.MovieCommentId);
                });
            modelBuilder.Entity<Movie>()
                .OwnsMany(x => x.Reviews, a =>
                {
                    a.WithOwner().HasForeignKey(z => z.MovieId);
                    a.HasKey(z => z.MovieReviewId);
                });

            modelBuilder.Entity<Movie>()
                .HasOne(x => x.Director);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Actors)
                .WithMany(x => x.Movies);


            base.OnModelCreating(modelBuilder);

        }
    }
}
