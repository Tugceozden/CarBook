﻿

namespace UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults
{
	public class GetFooterAddressByIdQueryResult
	{
		public int FooterAddressId { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
	}
}
