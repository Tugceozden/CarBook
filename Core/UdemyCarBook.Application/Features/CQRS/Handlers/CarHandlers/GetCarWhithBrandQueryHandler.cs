

using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWhithBrandQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarWhithBrandQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCarWhithBrandQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetCarWhithBrandQueryResult
			{
				BrandName=X.Brand.Name,
				BrandId = X.BrandId,
				BigİmageUrl = X.BigİmageUrl,
				CarId = X.CarId,
				CoverImageUrl = X.CoverImageUrl,
				Fuel = X.Fuel,
				KM = X.KM,
				Luggage = X.Luggage,
				Model = X.Model,
				Transmission = X.Transmission,
			}).ToList();






		}
	}
}