using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
	public  class GetBannerQueryHandler
	{

		private readonly IRepository<Banner> _repository;

		public GetBannerQueryHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetBannerQueryResult>> Handle()
		{
			var values=await  _repository.GetAllAsync();
			return values.Select(X => new GetBannerQueryResult
			{
				BannerId = X.BannerId,
			Title = X.Title,	
			Description = X.Description,
			VideoDescription = X.VideoDescription,
			VideoUrl = X.VideoUrl,
				
			}).ToList();

		}



	}
}
