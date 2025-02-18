﻿using System;
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
	public class CreateBrandCommandHandler
	{

		private readonly IRepository<Brand> repository;

		public CreateBrandCommandHandler(IRepository<Brand> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(CreateBrandCommand command)
		{

			await repository.CreateAsync(new Brand
			{
				Name = command.Name,


			});



		}
	}
}