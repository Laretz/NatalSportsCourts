using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.InsertBooking
{
    public class ValidateInsertBookingCommand :
        IPipelineBehavior<InsertBookingCommand, ResultViewModel<int>>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public ValidateInsertBookingCommand (QuadrasNatalDbContext context)
        {
            _contextDb = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertBookingCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var userExist = _contextDb.Users.Any(u => u.Id == request.IdUser);
            var courtExist = _contextDb.Courts.Any(u => u.Id == request.IdCourt);
            
            if(!userExist || !courtExist)
            {
                return ResultViewModel<int>.Error("Usuario ou Quadra não existe");
            }
            return await next();
        }
    }
}