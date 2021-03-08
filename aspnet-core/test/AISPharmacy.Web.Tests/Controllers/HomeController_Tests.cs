using System.Threading.Tasks;
using AISPharmacy.Models.TokenAuth;
using AISPharmacy.Web.Controllers;
using Shouldly;
using Xunit;

namespace AISPharmacy.Web.Tests.Controllers
{
    public class HomeController_Tests: AISPharmacyWebTestBase
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