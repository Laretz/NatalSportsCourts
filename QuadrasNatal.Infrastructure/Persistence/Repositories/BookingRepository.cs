using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Core.Entities;
using QuadrasNatal.Core.Repositories;

namespace QuadrasNatal.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public BookingRepository(QuadrasNatalDbContext contextDb )
        {
            _contextDb = contextDb;
        }
        public async Task<int> Add(Booking booking)
        {
            await _contextDb.Bookings.AddAsync(booking);
            await _contextDb.SaveChangesAsync();

            return booking.Id;
        }

        public async Task AddComment(Comment comment)
        {
            await _contextDb.CourtComments.AddAsync(comment);
            await _contextDb.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await _contextDb.Bookings.AnyAsync(b => b.Id == id);
        }

        public async Task<List<Booking>> GetAll()
        {
            
            var bookings = await _contextDb.Bookings
            .Include(b => b.User)
            .Include(b => b.Court)
            .Include(b => b.Comments)
            .Where(b => !b.IsDeleted )
            .ToListAsync();

            return bookings;
        }

        public async Task<Booking?> GetById(int id)
        {
            return await _contextDb.Bookings.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Booking?> GetDetailsById(int id)
        {
            var bookings = await _contextDb.Bookings
                .Include(b => b.User)
                .Include(b => b.Court)
                .Include(b => b.Comments)
                .SingleOrDefaultAsync(b=> b.Id == id );

            return bookings;
        }

        public async Task Update(Booking booking)
        {
            _contextDb.Bookings.Update(booking);
            await _contextDb.SaveChangesAsync();
        }
    }
}