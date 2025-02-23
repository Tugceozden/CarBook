using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
		private readonly GetCarQueryHandler _getCarQueryHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private readonly GetCarWhithBrandQueryHandler  _getCarWhithBrandQueryHandler;


		public CarsController(
			CreateCarCommandHandler createCarCommandHandler,
			GetCarByIdQueryHandler getCarByIdQueryHandler,
			GetCarQueryHandler getCarQueryHandler,
			UpdateCarCommandHandler updateCarCommandHandler,
			RemoveCarCommandHandler removeCarCommandHandler,
			GetCarWhithBrandQueryHandler getCarWhithBrandQueryHandler)
		{
			_createCarCommandHandler = createCarCommandHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_getCarWhithBrandQueryHandler = getCarWhithBrandQueryHandler;	
		}

		// Tüm arabaları listele
		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _getCarQueryHandler.Handle();
			return Ok(values);
		}
		

		// ID'ye göre tek bir arabayı getir
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
			return Ok(value);
		}

		// Yeni araba oluştur
		[HttpPost]
		public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand command)
		{
			if (command == null)
				return BadRequest("Geçersiz veri.");

			await _createCarCommandHandler.Handle(command);
			return Ok("Araba bilgisi eklendi.");
		}

		// ID'ye göre araba sil
		[HttpDelete("{id}")] // Buraya id ekledim!
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Araba bilgisi silindi.");
		}

		// Arabayı güncelle
		[HttpPut]
		public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
		{
			if (command == null)
				return BadRequest("Geçersiz veri.");

			await _updateCarCommandHandler.Handle(command);
			return Ok("Araba bilgisi güncellendi.");
		}
		[HttpGet("GetCarWhithBrand")]
		public IActionResult GetCarWhithBrand()
		{
			var values =  _getCarWhithBrandQueryHandler.Handle();
				return Ok(values);
		}

	}



}


	

