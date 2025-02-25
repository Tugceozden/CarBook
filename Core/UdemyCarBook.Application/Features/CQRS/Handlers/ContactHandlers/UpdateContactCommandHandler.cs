

using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class UpdateContactCommandHandler
	{
		private readonly IRepository<Contact> repository;

		public UpdateContactCommandHandler(IRepository<Contact> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(UpdateContactCommand command)
		{
			var values = await repository.GetByIdAsync(command.ContactId);
			values.Name = command.Name;
			values.Subject= command.Subject;	
			values.SendDate = command.SendDate;	
			values.Email = command.Email;
			values.Message = command.Message;	
			await repository.UpdateAsync(values);

		}

	}
}
