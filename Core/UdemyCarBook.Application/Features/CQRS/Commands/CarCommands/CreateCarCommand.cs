﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CarCommands
{
	public class CreateCarCommand
	{
		public int BrandId { get; set; }
		public Brand Brand { get; set; }
		public string Model { get; set; }
		public int CoverImageUrl { get; set; }
		public int KM { get; set; }
		public string Transmission { get; set; }
		public byte Seat { get; set; }
		public byte Luggage { get; set; }
		public string Fuel { get; set; }
		public string BigİmageUrl { get; set; }
	}
}
