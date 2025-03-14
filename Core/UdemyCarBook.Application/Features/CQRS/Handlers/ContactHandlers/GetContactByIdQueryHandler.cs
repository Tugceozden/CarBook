﻿
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;
using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactByIdQueryHandler
	{

		private readonly IRepository<Contact> _repository;

		public GetContactByIdQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}
		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetContactByIdQueryResult
			{
				ContactId = values.ContactId,
				Name = values.Name,
				Subject = values.Subject,
				SendDate = values.SendDate,
				Email = values.Email,
				Message = values.Message	
				


			};



		}
	}
}
