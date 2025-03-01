
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
	{
		private readonly IRepository<Service> _repository;

		public UpdateServiceCommandHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetByIdAsync(request.ServiceId);
			values.Title = request.Title;
			values.Description = request.Description;	
			values.ServiceId = request.ServiceId;
			values.IconUrl = request.IconUrl;	
			await _repository.UpdateAsync(values);
		}
	}
}
