
using QuadrasNatal.Core.Entities;

namespace QuadrasNatal.Application.Models
{
    public class UserViewModel
    { 
    
    public UserViewModel(string fullName, string email, DateTime birthDate, List<Booking> bookings)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Bookings = bookings;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public List<Booking> Bookings { get; private set; }

    public static UserViewModel FromEntity(User user)
    {
        var bookings = user.Bookings.Select(u => u.User.FullName);
        return new UserViewModel(user.FullName, user.Email, user.BithDate, user.Bookings);
    }
    }
}
