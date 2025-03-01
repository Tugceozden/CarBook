

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FetureResults;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
	{
		private readonly IRepository<Service> _repository;

		public GetServiceQueryHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetServiceQueryResult
			{
				ServiceId = X.ServiceId,
				Description = X.Description,
				IconUrl = X.IconUrl,
				Title= X.Title,	


			}).ToList();
		}
	}
}
