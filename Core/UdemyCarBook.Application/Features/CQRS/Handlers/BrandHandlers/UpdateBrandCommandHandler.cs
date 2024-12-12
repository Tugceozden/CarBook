using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public  class UpdateBrandCommandHandler
	{

		private readonly IRepository<Brand> repository;

		public UpdateBrandCommandHandler(IRepository<Brand> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(UpdateBrandCommand command)
		{
			var values = await repository.GetByIdAsync(command.BrandId);
			values.Name = command.Name;	
			await repository.UpdateAsync(values);

		}








	}
}
