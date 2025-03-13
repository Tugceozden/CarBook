

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FetureResults;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetAllAsync();
            return values.Select(X => new GetBlogQueryResult
            {
                BlogId = X.BlogId,
                AuthorId = X.AuthorId,
                CategoryId = X.CategoryId,
                CoverImageUrl = X.CoverImageUrl,
                CreatedDate = X.CreatedDate,
                Title = X.Title 
                

            }).ToList();
        }
    }
}
