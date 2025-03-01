

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FetureResults;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
	{
		private readonly IRepository<SocialMedia> _repository;

		public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetSocialMediaQueryResult
			{
				SocialMediaId = X.SocialMediaId,
				Name = X.Name,
				Icon=X.Icon,	
				Url=X.Url,	
				


			}).ToList();
		}
	}
}
