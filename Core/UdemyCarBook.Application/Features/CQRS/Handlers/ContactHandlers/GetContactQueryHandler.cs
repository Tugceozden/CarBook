

using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactQueryHandler
	{

		private readonly IRepository<Contact> _repository;

		public GetContactQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetContactQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(X => new GetContactQueryResult
			{
				ContactId = X.ContactId,
				Name = X.Name,
				Message = X.Message,
				Email = X.Email,
				SendDate = X.SendDate,
				Subject = X.Subject	
				
			}).ToList();


		}
	}
}