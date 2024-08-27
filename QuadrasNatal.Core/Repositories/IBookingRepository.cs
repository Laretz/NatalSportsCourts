using QuadrasNatal.Core.Entities;

namespace QuadrasNatal.Core.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAll();
        Task<Booking?> GetDetailsById(int id);
        Task<Booking?> GetById(int id);
        Task<int> Add (Booking booking);
        Task Update (Booking booking);
        Task AddComment (Comment comment);
        Task<bool> Exist(int id);
    }
}