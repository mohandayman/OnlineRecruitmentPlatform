using BussinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Online_Recruitment_Platform_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleAuthenticateController : ControllerBase
    {
        private readonly IGoogleService googleService;

        public GoogleAuthenticateController(IGoogleService GoogleService)
        {
            googleService = GoogleService;
        }

        [Route("GoogleRegister")]
        [HttpGet]
        public void GoogleRegister()
        {
            googleService.LoginUsingGoogle();


        }
    }
}
