﻿using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CarCommands
{
	public class CreateCarCommand
	{
		public int BrandId { get; set; }  
		public string Model { get; set; }
		public int CoverImageUrl { get; set; }  
		public int KM { get; set; }
		public string Transmission { get; set; }
		public byte Seat { get; set; }
		public byte Luggage { get; set; }
		public string Fuel { get; set; }
		public string BigImageUrl { get; set; } 
	}
}
