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
	public  class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(UpdateCarCommand command)
		{
			var values = await repository.GetByIdAsync(command.BrandId);
			values.Fuel = command.Fuel;
			values.Transmission = command.Transmission;
			values.Luggage = command.Luggage;
			values.Seat = command.Seat;	
			values.KM= command.KM;
			values.BigİmageUrl = command.BigİmageUrl;
			values.BrandId = command.BrandId;	
			values.CoverImageUrl = command.CoverImageUrl;	
			values.Model = command.Model;	



				await repository.UpdateAsync(values);

		}







	}
}
