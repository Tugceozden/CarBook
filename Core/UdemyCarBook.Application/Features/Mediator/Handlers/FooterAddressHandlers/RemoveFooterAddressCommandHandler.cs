﻿

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
	public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
	{
			var values=await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(values);
		}
	}
}
