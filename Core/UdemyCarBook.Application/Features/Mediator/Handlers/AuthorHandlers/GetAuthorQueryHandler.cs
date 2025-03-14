﻿

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FetureResults;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetAllAsync();
            return values.Select(X => new GetAuthorQueryResult
            {
                AuthorId = X.AuthorId,
                Name = X.Name,
                Description = X.Description,
                ImageUrl=X.ImageUrl,    


            }).ToList();
        }
    }
}
