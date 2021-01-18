using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Models;

namespace Test.Domain.IRepositories
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        public Task<List<ApplicationUser>> GetByIncludesAsync();
    }
}
