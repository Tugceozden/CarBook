using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarByIdQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarByIdQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}
		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetCarByIdQueryResult
			{
				CarId = values.CarId,
				BrandId = values.BrandId,
				BigİmageUrl = values.BigİmageUrl,
				CoverImageUrl = values.CoverImageUrl,
				Fuel = values.Fuel,
				KM = values.KM,
				Transmission = values.Transmission,
				Model = values.Model,
				Luggage = values.Luggage,
				Seat = values.Seat,


			};




		}
	}
}