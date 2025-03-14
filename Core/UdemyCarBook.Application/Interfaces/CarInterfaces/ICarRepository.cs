﻿

using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces
{
	public interface ICarRepository
	{
		List<Car> GetCarsListWithBrands();
		List<Car> GetLast5CarsWithBrands();
	}
}
