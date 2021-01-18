using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Application.IServices;
using Test.Domain.IRepositories;
using Test.Domain.Models;

namespace Test.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ApplicationUser>> GetByIncludesAsync()
        {
            return await _userRepository.GetByIncludesAsync();
        }

        public async Task<ApplicationUser> FindByIdAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }
    }
}
