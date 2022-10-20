using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Common;
using Sat.Recruitment.Common.Constants;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTests
    {

        private readonly Mock<ILogger<UsersController>> logger = new Mock<ILogger<UsersController>>();
        private readonly Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
        public UserControllerTests()
        {

        }

        [Fact]
        public async Task CreateUser_OnDuplicated_ShouldReturnError()
        {
            //Arrange
            UserModel usModel = new UserModel
            {
                Name = "Juan",
                Email = "Juan@marmol.com",
                Phone = "+5491154762312",
                UserType = "Normal",
                Address = "Peru 2464",
                Money = Convert.ToDecimal(1234)
            };
            var result = new Result
            {
                IsSuccess = false,
                Message = Constants.DuplicatedEmail
            };
            var user = new NormalUser("Juan", "Juan@marmol.com", "Peru 2464", "+5491154762312", UserTypes.Normal, Convert.ToDecimal(1234));
            userRepository.Setup(x => x.CreateUser(It.IsAny<User>(), CancellationToken.None))
                .ReturnsAsync(result);
            var usersController = new UsersController(userRepository.Object, logger.Object);
            //Act
            var resAct = await usersController.CreateUserAsync(usModel);

            //Assert
            Assert.Equal(resAct.Message, result.Message);
            Assert.False(resAct.IsSuccess);
        }
    }
}
