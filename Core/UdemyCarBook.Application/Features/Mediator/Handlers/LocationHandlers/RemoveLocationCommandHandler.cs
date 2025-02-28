﻿

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
	{
		private readonly IRepository<Location> _repository;

		public RemoveLocationCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
