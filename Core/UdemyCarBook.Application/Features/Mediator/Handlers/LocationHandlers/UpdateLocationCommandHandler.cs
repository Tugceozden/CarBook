﻿
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
	{
		private readonly IRepository<Location> _repository;

		public UpdateLocationCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public  async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetByIdAsync(request.LocationId);
			values.Name = request.Name;
			await _repository.UpdateAsync(values);
		}
	}
}
