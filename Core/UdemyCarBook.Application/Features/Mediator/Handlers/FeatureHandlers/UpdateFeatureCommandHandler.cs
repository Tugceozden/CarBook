﻿
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;

		public UpdateFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetByIdAsync(request.FeatureId);
			values.Name = request.Name;
			await _repository.UpdateAsync(values);
		}
	}
}
