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
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        private TestContext _context;
        public UserRepository(TestContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<List<ApplicationUser>> GetByIncludesAsync()
        {
            var userroles = _context.Users
                .Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .AsNoTracking().ToListAsync();
            return await userroles;
        }
    }
}
