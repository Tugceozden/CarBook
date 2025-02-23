using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
		private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
		private readonly GetCategoryQueryHandler getCategoryQueryHandler;
		private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;

		public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
		{
			this.createCategoryCommandHandler = createCategoryCommandHandler;
			this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
			this.getCategoryQueryHandler = getCategoryQueryHandler;
			this.updateCategoryCommandHandler = updateCategoryCommandHandler;
			this.removeCategoryCommandHandler = removeCategoryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{

			var values = await this.getCategoryQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]

		public async Task<IActionResult> GetCategory(int id)
		{
			var value = await this.getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

			return Ok(value);

		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
		{

			await this.createCategoryCommandHandler.Handle(command);
			return Ok("Kategori Bilgisi Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(int id)
		{

			await this.removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
			return Ok("Kategori Bilgisi Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
		{
			await this.updateCategoryCommandHandler.Handle(command);
			return Ok("Kategori Bilgisi Güncellendi.");

		}

	}

}

