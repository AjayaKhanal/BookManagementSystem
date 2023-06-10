using System.Threading.Tasks;
using BookManagementSystem.Controllers;
using BookManagementSystem.Models.TokenAuth;
using BookManagementSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace BookManagementSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: BookManagementSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}