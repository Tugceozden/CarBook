﻿
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults
{
	public class GetSocialMediaQueryResult
	{
		public int SocialMediaId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

	}
}
