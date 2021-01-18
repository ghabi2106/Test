using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Models;

namespace Test.Application.IServices
{
    public interface ICityService
    {
        public Task<City> GetByIdIncludesAsync(int id, DateTime date);
    }
}
