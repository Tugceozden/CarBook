
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.BlogId);
            values.AuthorId = request.AuthorId; 
            values.CreatedDate = request.CreatedDate;   
            values.CategoryId = request.CategoryId; 
            values.Title = request.Title;   
            
            await _repository.UpdateAsync(values);
        }
    }
}
