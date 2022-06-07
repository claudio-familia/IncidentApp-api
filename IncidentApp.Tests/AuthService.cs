using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IncidentApp.Tests
{
    public class AuthService
    {
        private Mock<IAuthService> authService;
        private string userName = "Administrator";
        private string password = "1234";
        public AuthService()
        {
            authService = new Mock<IAuthService>();
        }


        [Fact]
        public void TryLoginWithCorrectUser()
        {
            var mockResponse = new OkObjectResult(new { userName, token = "Some random token" });
            authService.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))
                        .Returns(mockResponse);


            var response = authService.Object.Login(userName, password) as ObjectResult;


            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(response.Value, new { userName, token = "Some random token" });
        }

        [Fact]
        public void TryLoginWithNotExistingUser()
        {
            userName = "not found user";
            var mockResponse = new NotFoundObjectResult("Invalid User");
            authService.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))
                        .Returns(mockResponse);

            var response = authService.Object.Login(userName, password) as ObjectResult;

            Assert.IsType<NotFoundObjectResult>(response);
            Assert.Equal("Invalid User", response.Value);
        }

        [Fact]
        public void TryLoginWithInvalidCredentials()
        {
            password = "wrong password";
            var mockResponse = new UnauthorizedObjectResult("Invalid Password");
            authService.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))
                        .Returns(mockResponse);

            var response = authService.Object.Login(userName, password) as ObjectResult;

            Assert.IsType<UnauthorizedObjectResult>(response);
            Assert.Equal("Invalid Password", response.Value);
        }
    }
}
