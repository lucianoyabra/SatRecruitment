using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(CancellationToken ct);
        Task<Result> CreateUser(User user, CancellationToken ct);
        Result IsValid(User user, List<User> userData);
    }
}
