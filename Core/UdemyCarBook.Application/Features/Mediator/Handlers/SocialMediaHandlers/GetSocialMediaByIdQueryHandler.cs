

using MediatR;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
	{
		private readonly IRepository<SocialMedia> _repository;

		public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetSocialMediaByIdQueryResult
			{
				SocialMediaId = values.SocialMediaId,
				Name = values.Name,
				Icon = values.Icon,
				Url= values.Url,	
				


			};
		}
	}
}
