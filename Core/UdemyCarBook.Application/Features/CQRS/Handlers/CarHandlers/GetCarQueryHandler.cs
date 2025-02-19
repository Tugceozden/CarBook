using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public  class GetCarQueryHandler
	{

		private readonly IRepository<Car> _repository;

		public GetCarQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCarQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetCarQueryResult
			{
				BrandId = X.BrandId,
				BigİmageUrl =X.BigİmageUrl,
				CarId = X.CarId,
				CoverImageUrl =X.CoverImageUrl,
				Fuel=X.Fuel,	
			    KM=X.KM,	
				Luggage=X.Luggage,
				Model=X.Model,
				Transmission=X.Transmission,	
			}).ToList();







		}
	}}
