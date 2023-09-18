using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer;

public interface IGoogleService
{
    public void LoginUsingGoogle();
    public  Task<UserProfile> GetuserProfile(string accesstoken);
    public Task<UserProfile> HandleGoogleResponse(string Code, string State = null , string SissionState = null);


}
