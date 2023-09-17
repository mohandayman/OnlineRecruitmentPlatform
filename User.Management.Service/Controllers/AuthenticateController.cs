using BussinessLayer;
using DataAccessLayer_DAL_;
using DataAccessLayer_DAL_.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Recruitment_Platform_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IAuthenticationService AuthenticationService { get; }

        public AuthenticateController( IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }


        //[HttpPost]
        //[Route("Login")] 
        //public async Task<IActionResult> Login([FromBody] Login_Model Model)
        //{
        //    var Result = await AuthenticationService.Login(Model);

        //    if (Result!=null)
        //        return Ok(Result);
        //    // if problem occured
        //    return StatusCode(StatusCodes.Status500InternalServerError, Result);
        //}

        [HttpPost]
        [Route("register-employee")]

        public async Task<IActionResult> Register_Employee(Register_Model Model)
        {

            var Result = await AuthenticationService.Employee_Register(Model);

            if (Result.Status.Equals("Success"))
                return Ok(Result);
            // if problem occured
            return StatusCode(StatusCodes.Status500InternalServerError, Result);



        }



        [HttpPost]
        [Route("register-compuny")]
        public async Task<IActionResult> Register_Compuny([FromBody] Register_Model Model)
        {
            var Result = await AuthenticationService.Compuny_Register(Model);

            if (Result.Status.Equals("Success"))
                return Ok(Result);
            // if problem occured
            return StatusCode(StatusCodes.Status500InternalServerError, Result);
        }
     

    }
}
