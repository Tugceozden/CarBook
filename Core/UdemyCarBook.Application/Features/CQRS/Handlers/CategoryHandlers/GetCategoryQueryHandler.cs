

using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryQueryHandler
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCategoryQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetCategoryQueryResult
			{
				CategoryId = X.CategoryId,
				Name = X.Name,
			}).ToList();
		}
	}
}
