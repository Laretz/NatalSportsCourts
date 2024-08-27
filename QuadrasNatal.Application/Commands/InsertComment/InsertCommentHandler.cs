using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Entities;
using QuadrasNatal.Core.Repositories;

namespace QuadrasNatal.Application.Commands.InsertComment
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IBookingRepository _repository;
        public InsertCommentHandler(IBookingRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var exist = await _repository.Exist(request.IdBooking);

            if (!exist)
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            var comment = new Comment(request.Content, request.IdCourt, request.IdUser, request.IdBooking);

            await _repository.AddComment(comment);

            return ResultViewModel.Sucess();
        }
    }
}

