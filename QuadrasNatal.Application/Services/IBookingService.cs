using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Entities;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Services
{
    public interface IBookingService
    {   

        ResultViewModel <List<BookingViewModel>>GetAll(string search);
        ResultViewModel<BookingViewModel> GetById (int id);
        ResultViewModel<int> Insert (CreateBookingInputModel model); 
        ResultViewModel Update (UpdateBookingInputeModel model);
        ResultViewModel Delete (int id);
        ResultViewModel Start (int id);
        ResultViewModel Finish (int id);
        ResultViewModel InsertComment (int id, CreateCommentInputModel model);
    }

    
}