

using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.FetureResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries
{
	public class GetFeatureQuery:IRequest<List<GetFeatureQueryResult>>
	{
	}
}
