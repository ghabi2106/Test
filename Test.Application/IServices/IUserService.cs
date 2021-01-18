using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Models;

namespace Test.Application.IServices
{
    public interface IUserService
    {
        public Task<List<ApplicationUser>> GetByIncludesAsync();
        public Task<ApplicationUser> FindByIdAsync(int id);
    }
}
