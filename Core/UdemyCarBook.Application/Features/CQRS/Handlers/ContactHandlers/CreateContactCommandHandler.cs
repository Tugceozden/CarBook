

using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class CreateContactCommandHandler
	{
		private readonly IRepository<Contact> repository;

		public CreateContactCommandHandler(IRepository<Contact> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(CreateContactCommand command)
		{

			await repository.CreateAsync(new Contact
			{
				Name = command.Name,
				Email= command.Email,	
				Message = command.Message,	
				SendDate = command.SendDate,	
				Subject = command.Subject	


			});
		}
	}
}