﻿

using MediatR;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
	public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery,
		GetFooterAddressByIdQueryResult>
	{
		private readonly IRepository<FooterAddress> _repository;

		public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public  async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);

			return new GetFooterAddressByIdQueryResult
			{
				Address = values.Address,
				Description = values.Description,
				Email = values.Email,
				FooterAddressId = values.FooterAddressId,
				Phone = values.Phone,
			};

			

		}
	}
}
