﻿

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
	public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async  Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
	{
			var values = await _repository.GetByIdAsync(request.FooterAddressId);
			values.Phone = request.Phone;
		    values.Address=request.Address;	
			values.Description = request.Description;	
			values.Email = request.Email;	
			await _repository.UpdateAsync(values);
		}
	}
}
