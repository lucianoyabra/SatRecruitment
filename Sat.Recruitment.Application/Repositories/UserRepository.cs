using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Common.Constants;
using Sat.Recruitment.Data.Helpers;
using Sat.Recruitment.Data.Mappers;
using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string path;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            path = _configuration["UsersFilePath"];
        }
        public async Task<Result> CreateUser(User user, CancellationToken ct)
        {
            var users = await GetUsers(ct);
            var result = IsValid(user, users);
            if (result.IsSuccess)
            {
                var userArr = UserMapperHelper.GetUserToString(user);
                result = await FileOpenerHelper.AddUserAsync(path, string.Join(',', userArr));
            }
            return result;
        }

        public async Task<List<User>> GetUsers(CancellationToken ct)
        {
            var csvData = FileOpenerHelper.ReadUsersFromFile(path);
            var users = await UserMapperHelper.MapToUsers(csvData);
            return users;
        }

      

        public Result IsValid(User user, List<User> users)
        {
            var result = new Result();
            result.IsSuccess = true;
            var sameEmail = users.FirstOrDefault(u => u.Email == user.Email);
            var samePhone = users.FirstOrDefault(u => u.Phone == user.Phone);
            var sameNameAddress = users.FirstOrDefault(u => (u.Name == user.Phone) && (u.Address == user.Address));
            if (sameEmail != null)
            {
                result.Message = Constants.DuplicatedEmail;
                result.IsSuccess = false;
            }
            if (samePhone != null)
            {
                result.Message = Constants.DuplicatedPhone;
                result.IsSuccess = false;
            }
            if (sameNameAddress != null)
            {
                result.Message = Constants.DuplicatedNameAddres;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
