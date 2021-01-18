using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.IRepositories;
using Test.Domain.Models;
using Test.Infra.Data.Context;

namespace Test.Infra.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        private TestContext _context;
        public CityRepository(TestContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<City> GetByIdIncludesAsync(int id, DateTime date)
        {
            var cityWeathers = _context.Cities
                .Where(c => c.Id == id)
                .Include(ur => ur.Weathers.Where(w=>w.Date == date))
                .AsNoTracking().FirstOrDefaultAsync();
            return await cityWeathers;
        }
    }
}
