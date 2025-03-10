﻿
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryByIdQueryHandler
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryByIdQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}
		public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetCategoryByIdQueryResult
			{
				CategoryId = values.CategoryId,
				Name = values.Name,


			};
		}
	}
}