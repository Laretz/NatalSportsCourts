using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Core.Entities;

namespace QuadrasNatal.Infrastructure.Persistence
{
    public class QuadrasNatalDbContext : DbContext
    {
        public QuadrasNatalDbContext (DbContextOptions<QuadrasNatalDbContext> options) : base (options)
        {
            
        }

        public DbSet<Court> Courts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Comments> CourtComments { get; set; }

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

                    e.HasMany(u => u.Bookings)
                        .WithOne(r => r.User)
                        .HasForeignKey(r => r.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasMany(u => u.Comments)
                        .WithOne(cc => cc.User)
                        .HasForeignKey(cc => cc.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });
            
            builder
                .Entity<Comments>(e =>
                {
                    e.HasKey(cc => cc.Id);

                    e.HasOne(cc => cc.Court)
                        .WithMany(c => c.Comments)
                        .HasForeignKey(cc => cc.IdCourt)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(cc => cc.User)
                        .WithMany(u => u.Comments)
                        .HasForeignKey(cc => cc.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(cc => cc.Booking)
                        .WithMany(b => b.Comments)
                        .HasForeignKey(cc => cc.IdBooking)
                        .OnDelete(DeleteBehavior.Restrict);    
                });
                
             builder
                .Entity<Booking>(e =>
                {
                    e.HasKey(r => r.Id);

                    e.HasOne(r => r.User)
                        .WithMany(u => u.Bookings)
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