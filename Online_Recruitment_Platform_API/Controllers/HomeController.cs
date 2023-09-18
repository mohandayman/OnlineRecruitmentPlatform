using BussinessLayer;
using DataAccessLayer_DAL_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Recruitment_Platform_API.Controllers
{
    [Authorize(Roles = UserRoles.Employee)]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGoogleService googleService;

        public HomeController(IGoogleService GoogleService)
        {
            googleService = GoogleService;
        }



        // GET: api/<HomeController>
        [HttpGet]
        public async Task <  ActionResult<UserProfile> > GetHomePage( string code)
        {
           
         var Google_User_Data  = await googleService.HandleGoogleResponse( code );
            return Google_User_Data;
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
