using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadrasNatal.API.Entities;

namespace QuadrasNatal.API.Models
{
    public class UserViewModel
    { 
    
    public UserViewModel(string fullName, string email, DateTime birthDate)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }

    public static UserViewModel FromEntity(User user)
    {
        return new UserViewModel(user.FullName, user.Email, user.BithDate);
    }
    }
}
