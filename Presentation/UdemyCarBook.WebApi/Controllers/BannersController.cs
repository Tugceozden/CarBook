﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{

		private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private	readonly  CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;	
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

		public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
		{
			_getBannerByIdQueryHandler = getBannerByIdQueryHandler;
			_getBannerQueryHandler = getBannerQueryHandler;
			_createBannerCommandHandler = createBannerCommandHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
			_removeBannerCommandHandler = removeBannerCommandHandler;
		}


		[HttpGet]

		public async Task<IActionResult> BannerList()
		{
			var values = await _getBannerQueryHandler.Handle();
			return Ok(values);	
		}
		[HttpGet ("{id}")]	

		public  async Task<IActionResult> GetBanner(int id) 
		{ 
		var value=await  _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
			return Ok(value);	
		}
		[HttpPost]

		public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
		{
			await _createBannerCommandHandler.Handle(command);
			return Ok(" bilgi eklendi.");	

		}

		[HttpDelete]

		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
			return Ok("bilgi silindi.");

		}
		[HttpPut]

		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
		{
			await _updateBannerCommandHandler.Handle(command);
			return Ok(" bilgi güncellendi.");

		}



	}
}
