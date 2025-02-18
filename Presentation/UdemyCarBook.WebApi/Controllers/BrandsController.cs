using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{

		private readonly CreateBrandCommandHandler createBrandCommandHandler;
		private readonly GetBrandByIdQueryHandler getBrandByIdQueryHandler;
		private readonly GetBrandQueryHandler getBrandQueryHandler;
		private readonly UpdateBrandCommandHandler updateBrandCommandHandler;
		private readonly RemoveBrandCommandHandler removeBrandCommandHandler;

		public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
		{
			this.createBrandCommandHandler = createBrandCommandHandler;
			this.getBrandByIdQueryHandler = getBrandByIdQueryHandler;
			this.getBrandQueryHandler = getBrandQueryHandler;
			this.updateBrandCommandHandler = updateBrandCommandHandler;
			this.removeBrandCommandHandler = removeBrandCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> BrandList()
		{

			var values = await this.getBrandQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]

		public async Task<IActionResult> GetBrand(int id)
		{
			var value = await this.getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));

			return Ok(value);

		}
		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
		{

			await this.createBrandCommandHandler.Handle(command);
			return Ok("Marka Bilgisi Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBrand(int id)
		{

			await this.removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
			return Ok("Marka Bilgisi Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
		{
			await this.updateBrandCommandHandler.Handle(command);
			return Ok("Marka Bilgisi Güncellendi.");

		}

	}



}

