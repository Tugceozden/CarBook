﻿

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _repository;

		public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new SocialMedia
			{
				Name = request.Name,


			});
		}
	}
}
