using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialAuthentication.Helper.HttpClient;
using SocialAuthentication.Models;

namespace SocialAuthentication.Controllers
{
    [Route("api/v3/account")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login-by-facebook-fe")]
        public async Task<IActionResult> LoginByFacebookFE([FromBody] LoginByFacebookViewModel model)
        {
            try
            {
                var requestUri = "https://graph.facebook.com/me";

                var urlParams = new System.Collections.Generic.Dictionary<string, string>
                {
                    { "fields", "id,first_name,last_name,name,picture" },
                    { "access_token", model.AccessToken}
                };

                var queryString1 = string.Join("&", urlParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));

                var response = await HttpRequestFactory.Get($"{requestUri}?{queryString1}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Login fail.");
                }

                var userInfoResult = response.ContentAsType<FacebookUserModel>();

                return Ok(userInfoResult);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message,
                });
            }
        }
    }
}
