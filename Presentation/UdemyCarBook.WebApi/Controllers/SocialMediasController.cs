﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SocialMediasController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> SocialMediaList()
		{
			var values = await _mediator.Send(new GetSocialMediaQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSocialMedia(int id)
		{
			var values = await _mediator.Send(new GetSocialMediaByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sosyal Medya başarıyla eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveFaeture(int id)
		{
			await _mediator.Send(new RemoveSocialMediaCommand(id));
			return Ok("Sosyal Medya başarıyla silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sosyal Medya başarıyla güncellendi.");
		}


	}
}
