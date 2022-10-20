using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Models;
using Sat.Recruitment.Data.Repositories;
using System.Threading;
using Newtonsoft.Json;
using Sat.Recruitment.Common;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly List<User> _users = new List<User>();
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository,
            ILogger<UsersController> logger)
        {
            this._userRepository = userRepository;
            this.logger = logger;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUserAsync(UserModel user, CancellationToken ct = default)
        {
            Result result = UserModelValidator.IsValidUser(ref user);
            if (!result.IsSuccess) {
                logger.LogInformation($"User validation failed on { result.Message }");
                return result;
            }
            var newUser = UserFactory.CreateUser(user);
            try
            {
                logger.LogInformation($"UserController to create new User{ JsonConvert.SerializeObject(newUser) }");
                result = await _userRepository.CreateUser(newUser, ct);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                logger.LogInformation($"User could not be created { ex.Message }");
                return result;
            }
            var message = result.IsSuccess ? "User created successfully" : result.Message;
            logger.LogInformation(message);
            return result;
        }
        
    }
    
}
