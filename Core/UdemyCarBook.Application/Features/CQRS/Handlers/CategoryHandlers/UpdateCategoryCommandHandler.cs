

using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class UpdateCategoryCommandHandler
	{
		private readonly IRepository<Category> repository;

		public UpdateCategoryCommandHandler(IRepository<Category> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(UpdateCategoryCommand command)
		{
			var values = await repository.GetByIdAsync(command.CategoryId);
			values.Name = command.Name;
			await repository.UpdateAsync(values);

		}

	}
}
