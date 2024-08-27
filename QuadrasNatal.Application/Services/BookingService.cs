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
    public class BookingService : IBookingService
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public BookingService(QuadrasNatalDbContext contextDb )
        {
            _contextDb = contextDb;
        }
        public ResultViewModel Delete(int id)
        {
             var booking = _contextDb.Bookings.SingleOrDefault(b=> b.Id == id);
            if (booking == null )
            {
                return ResultViewModel.Error("Projeto nao encontrado");
            }

            booking.SetAsDeleted();
            _contextDb.Bookings.Update(booking);
            _contextDb.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel Finish(int id)
        {
            var booking = _contextDb.Bookings.SingleOrDefault(b=> b.Id == id);
            if (booking == null )
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            booking.Finish();
            _contextDb.Bookings.Update(booking);
            _contextDb.SaveChanges();
            
            return ResultViewModel.Sucess();
        }

        public ResultViewModel<List<BookingViewModel>> GetAll(string search = "")
        {
            var bookings = _contextDb.Bookings
            .Include(b => b.User)
            .Include(b => b.Court)
            .Include(b => b.Comments)
            .Where(b => !b.IsDeleted && (search== "" || b.Description.Contains(search)) ||  b.Sport.Contains(search))
            .ToList();

            var model = bookings.Select(BookingViewModel.FromEntity).ToList();
            
            return ResultViewModel<List<BookingViewModel>>.Sucess(model);
        }

        public ResultViewModel<BookingViewModel> GetById(int id)
        {
            var bookings = _contextDb.Bookings
                .Include(b => b.User)
                .Include(b => b.Court)
                .Include(b => b.Comments)
                .SingleOrDefault(b=> b.Id == id);

            if (bookings is null)
            {
                return ResultViewModel<BookingViewModel>.Error("Projeto nao existente.");
            }

            var model = BookingViewModel.FromEntity(bookings);

            return ResultViewModel<BookingViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateBookingInputModel model)
        {
            var booking = model.ToEntity();

            _contextDb.Bookings.Add(booking);
            _contextDb.SaveChanges();

            return ResultViewModel<int>.Sucess(booking.Id);
        }

        public ResultViewModel InsertComment(int id, CreateCommentInputModel model)
        {
              var booking = _contextDb.Bookings.SingleOrDefault(b=> b.Id == id);
            if (booking == null )
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            var comment = new Comments(model.Content, model.IdCourt, model.IdUser, model.IdBooking);
            _contextDb.CourtComments.Add(comment);
            _contextDb.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel Start(int id)
        {
            var booking = _contextDb.Bookings.SingleOrDefault(b=> b.Id == id);
                if (booking == null )
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            booking.Start();
            _contextDb.Bookings.Update(booking);
            _contextDb.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel Update(UpdateBookingInputeModel model)
        {
            var booking = _contextDb.Bookings.SingleOrDefault(b=> b.Id == model.IdBooking);

            if (booking == null )
            {
                return ResultViewModel.Error("Projeto nao existe.");
            }

            booking.Update(model.Description, model.Sport);

            _contextDb.Bookings.Update(booking);
            _contextDb.SaveChanges();

            return ResultViewModel.Sucess();
        }
    }
}