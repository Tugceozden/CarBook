
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.AuthorId);
            values.Name = request.Name;
            values.ImageUrl = request.ImageUrl;
            values.AuthorId = request.AuthorId;
            values.Description = request.Description;   
            
            await _repository.UpdateAsync(values);
        }
    }
}
