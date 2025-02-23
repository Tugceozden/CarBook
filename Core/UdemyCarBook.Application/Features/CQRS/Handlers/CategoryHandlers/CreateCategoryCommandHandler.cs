
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class CreateCategoryCommandHandler
	{

		private readonly IRepository<Category> repository;

		public CreateCategoryCommandHandler(IRepository<Category> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(CreateCategoryCommand command)
		{

			await repository.CreateAsync(new Category
			{
				Name = command.Name,


			});
		}
	}
}