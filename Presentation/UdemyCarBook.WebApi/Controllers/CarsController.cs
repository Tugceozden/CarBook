using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{

		private readonly CreateCarCommandHandler createCarCommandHandler;
		private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
		private readonly GetCarQueryHandler getCarQueryHandler;
		private readonly UpdateCarCommandHandler updateCarCommandHandler;
		private readonly RemoveCarCommandHandler removeCarCommandHandler;

		public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler)
		{
			this.createCarCommandHandler = createCarCommandHandler;
			this.getCarByIdQueryHandler = getCarByIdQueryHandler;
			this.getCarQueryHandler = getCarQueryHandler;
			this.updateCarCommandHandler = updateCarCommandHandler;
			this.removeCarCommandHandler = removeCarCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> CarList()
		{

			var values = await this.getCarQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]

		public async Task<IActionResult> GetCar(int id)
		{
			var value = await this.getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));

			return Ok(value);

		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{

			await this.createCarCommandHandler.Handle(command);
			return Ok("Marka Bilgisi Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCar(int id)
		{

			await this.removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Marka Bilgisi Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			await this.updateCarCommandHandler.Handle(command);
			return Ok("Marka Bilgisi Güncellendi.");

		}

	}



}


	

