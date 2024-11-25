using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly CreateAboutCommandHandler createAboutCommandHandler;
		private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
		private readonly GetAboutQueryHandler getAboutQueryHandler;
		private readonly UpdateAboutCommandHandler updateAboutCommandHandler;
		private readonly RemoveAboutCommandHandler removeAboutCommandHandler;

		public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
		{
			this.createAboutCommandHandler = createAboutCommandHandler;
			this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
			this.getAboutQueryHandler = getAboutQueryHandler;
			this.updateAboutCommandHandler = updateAboutCommandHandler;
			this.removeAboutCommandHandler = removeAboutCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> AboutList()
		{

			var values = await this.getAboutQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]

		public async Task<IActionResult> GetAbout(int id)
		{
		var value = await this.getAboutByIdQueryHandler.Handle( new GetAboutByIdQuery(id));

			return Ok(value);

}
		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
		{

			await this.createAboutCommandHandler.Handle( command );
			return Ok("Hakkımda Bilgisi Eklendi.");	
		}

			
	}
}
