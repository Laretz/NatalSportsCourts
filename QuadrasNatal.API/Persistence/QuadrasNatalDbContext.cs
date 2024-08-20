using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.API.Entities;

namespace QuadrasNatal.API.Persistence
{
    public class QuadrasNatalDbContext : DbContext
    {
        public QuadrasNatalDbContext (DbContextOptions<QuadrasNatalDbContext> options) : base (options)
        {
            
        }

        public DbSet<Court> Courts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Reservas { get; set; }
        public DbSet<CourtComments> CourtComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Court>(e =>
                {
                    e.HasKey(c => c.Id);

                    e.HasMany(c => c.Reservations)
                        .WithOne(c => c.Court)
                        .HasForeignKey(r => r.IdCourt)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasMany(c => c.Comments)
                        .WithOne(c => c.Court)
                        .HasForeignKey(c => c.IdCourt)
                        .OnDelete(DeleteBehavior.Restrict);
                    
                });
                

            builder
                .Entity<User>(e => 
                {
                    e.HasKey(u => u.Id);

                    e.HasMany(u => u.Reservas)
                        .WithOne(r => r.User)
                        .HasForeignKey(r => r.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });
            
            builder
                .Entity<CourtComments>(e =>
                {
                    e.HasKey(cc => cc.Id);

                    e.HasOne(cc => cc.Court)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(cc => cc.IdCourt)
                        .OnDelete(DeleteBehavior.Restrict);
                });
                
             builder
                .Entity<Booking>(e =>
                {
                    e.HasKey(r => r.Id);

                    e.HasOne(r => r.User)
                        .WithMany(u => u.Reservas)
                        .HasForeignKey(r => r.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(r => r.Court)
                        .WithMany(c => c.Reservations)
                        .HasForeignKey(r => r.IdCourt)
                        .OnDelete(DeleteBehavior.Restrict);
                });
                
            base.OnModelCreating(builder);
        }
    }
}