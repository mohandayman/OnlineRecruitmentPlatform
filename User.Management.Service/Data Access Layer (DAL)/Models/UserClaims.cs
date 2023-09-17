using Microsoft.AspNetCore.Identity;

namespace User.Management.Service.Data_Access_Layer__DAL_.Models
{
    public class IdentityEmployeeClaim : IdentityUserClaim<string> { }
    public class IdentityCompunyClaim : IdentityUserClaim<string> { }
}
