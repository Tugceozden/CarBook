﻿

using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWhithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarWhithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public  List<GetCarWhithBrandQueryResult> Handle()
		{
			var values =  _repository.GetCarsListWithBrands();
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