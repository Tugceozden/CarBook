using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly CreateContactCommandHandler createContactCommandHandler;
		private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
		private readonly GetContactQueryHandler getContactQueryHandler;
		private readonly UpdateContactCommandHandler updateContactCommandHandler;
		private readonly RemoveContactCommandHandler removeContactCommandHandler;

		public ContactsController(CreateContactCommandHandler createContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
		{
			this.createContactCommandHandler = createContactCommandHandler;
			this.getContactByIdQueryHandler = getContactByIdQueryHandler;
			this.getContactQueryHandler = getContactQueryHandler;
			this.updateContactCommandHandler = updateContactCommandHandler;
			this.removeContactCommandHandler = removeContactCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> ContactList()
		{

			var values = await this.getContactQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]

		public async Task<IActionResult> GetContact(int id)
		{
			var value = await this.getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));

			return Ok(value);

		}
		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactCommand command)
		{

			await this.createContactCommandHandler.Handle(command);
			return Ok("İletişim Bilgisi Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveContact(int id)
		{

			await this.removeContactCommandHandler.Handle(new RemoveContactCommand(id));
			return Ok("İletişim Bilgisi Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
		{
			await this.updateContactCommandHandler.Handle(command);
			return Ok("İletişim Bilgisi Güncellendi.");

		}

	}

}

