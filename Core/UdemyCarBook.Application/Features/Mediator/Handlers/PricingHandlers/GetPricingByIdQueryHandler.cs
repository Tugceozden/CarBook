﻿

using MediatR;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
	{
		private readonly IRepository<Pricing> _repository;

		public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetPricingByIdQueryResult
			{
				PricingId = values.PricingId,
				Name = values.Name,


			};
		}
	}
}
