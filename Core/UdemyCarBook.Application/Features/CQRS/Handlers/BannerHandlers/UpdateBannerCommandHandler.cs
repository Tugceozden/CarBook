using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
	public  class UpdateBannerCommandHandler
	{

		private readonly IRepository<Banner> repository;

		public UpdateBannerCommandHandler(IRepository<Banner> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(UpdateBannerCommand command)
		{
			var values = await repository.GetByIdAsync(command.BannerId);
			values.Description = command.Description;
			values.Title = command.Title;
			values.VideoUrl = command.VideoUrl;
			values.VideoDescription = command.VideoDescription;	
			await repository.UpdateAsync(values);

		}



	}
}
