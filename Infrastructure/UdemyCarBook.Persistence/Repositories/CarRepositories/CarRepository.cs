﻿
using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _context;
        public CarRepository(CarBookContext context)
        {
			_context = context;
        }
        public List<Car> GetCarsListWithBrands()
		{
			var values=_context.Cars.Include(x=>x.Brand).ToList();
			return values;	


		}

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand)
                .OrderByDescending(x => x.CarId).Take(5).ToList();
            return values;  
        }
    }
}
