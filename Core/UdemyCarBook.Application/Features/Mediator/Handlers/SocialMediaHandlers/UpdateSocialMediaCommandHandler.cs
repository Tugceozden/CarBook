﻿
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _repository;

		public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetByIdAsync(request.SocialMediaId);
			values.Name = request.Name;
			values.Url = request.Url;
			values.SocialMediaId = request.SocialMediaId;	
			values.Icon= request.Icon;	
			await _repository.UpdateAsync(values);
		}
	}
}
