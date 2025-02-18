using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> repository;

		public CreateCarCommandHandler(IRepository<Car> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(CreateCarCommand command)
		{

			await repository.CreateAsync(new Car
			{
				BigİmageUrl = command.BigImageUrl,
				Fuel = command.Fuel,
				KM = command.KM,
				Luggage = command.Luggage,
				Model = command.Model,
				Seat = command.Seat,
				BrandId = command.BrandId,
				Transmission = command.Transmission,
				CoverImageUrl = command.CoverImageUrl,

			});





		}
	}
}
