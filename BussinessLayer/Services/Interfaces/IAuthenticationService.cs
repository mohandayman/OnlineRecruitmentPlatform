using DataAccessLayer_DAL_;
using DataAccessLayer_DAL_.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer;

public interface IAuthenticationService
{
    public Task<Response> Employee_Register( Register_Model Model);
    public Task<Response> Compuny_Register(Register_Model Model);
    public Task<TokenDto> Login(Login_Model Model);


}
