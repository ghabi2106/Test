using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Application.IServices;
using Test.Domain.IRepositories;
using Test.Domain.Models;

namespace Test.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<City> GetByIdIncludesAsync(int id, DateTime date)
        {
            return await _cityRepository.GetByIdIncludesAsync(id, date);
        }
    }
}
