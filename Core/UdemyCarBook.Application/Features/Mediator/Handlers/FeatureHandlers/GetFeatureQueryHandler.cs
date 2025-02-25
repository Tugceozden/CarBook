
using MediatR;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FetureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
	{
		private readonly IRepository<Feature> _repository;
        public GetFeatureQueryHandler(IRepository<Feature>repository)
        {
			_repository = repository;	
				
        }
        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetFeatureQueryResult
			{
				FeatureId = X.FeatureId,
				Name = X.Name,
				
			}).ToList();
		}
	}
}
