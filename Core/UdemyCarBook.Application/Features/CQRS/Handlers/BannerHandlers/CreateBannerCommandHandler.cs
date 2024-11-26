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
	public class CreateBannerCommandHandler
	{
		private readonly IRepository<Banner> repository;

		public CreateBannerCommandHandler(IRepository<Banner> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(CreateBannerCommand command)
		{

			await repository.CreateAsync(new Banner
			{
				Title = command.Title,
				Description = command.Description,
				VideoDescription = command.VideoDescription,
				VideoUrl = command.VideoUrl,


			});




		}
	}
}