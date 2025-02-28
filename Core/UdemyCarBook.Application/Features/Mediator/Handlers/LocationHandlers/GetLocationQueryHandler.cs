

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FetureResults;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery,List<GetLocationQueryResult>>
	{
		private readonly IRepository<Location> _repository;

		public GetLocationQueryHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetLocationQueryResult
			{
				LocationId = X.LocationId,
				Name = X.Name,
				

			}).ToList();
		}
	}
}
