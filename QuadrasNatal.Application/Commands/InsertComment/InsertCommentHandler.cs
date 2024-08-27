using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Entities;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.InsertComment
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public InsertCommentHandler(QuadrasNatalDbContext contextDb )
        {
            _contextDb = contextDb;
        }
        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var booking = await _contextDb.Bookings.SingleOrDefaultAsync(b=> b.Id == request.IdBooking);
            if (booking == null )
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            var comment = new Comments(request.Content, request.IdCourt, request.IdUser, request.IdBooking);
            await _contextDb.CourtComments.AddAsync(comment);
            await _contextDb.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}