﻿

namespace UdemyCarBook.Application.Features.CQRS.Results.CarResults
{
	public class GetCarWithBrandQueryResult
	{
		public int CarId { get; set; }
		public int BrandId { get; set; }
		public string BrandName { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public int KM { get; set; }
		public string Transmission { get; set; }
		public byte Seat { get; set; }
		public byte Luggage { get; set; }
		public string Fuel { get; set; }
		public string BigİmageUrl { get; set; }
	}
}
