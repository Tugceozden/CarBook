﻿
using MediatR;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
	{
		private readonly IRepository<Feature> _repository;

		public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetFeatureByIdQueryResult
			{
				FeatureId = values.FeatureId,
				Name = values.Name,


			};
		}
	}
}
