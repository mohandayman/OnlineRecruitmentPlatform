using DataAccessLayer_DAL_;
using DataAccessLayer_DAL_.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using User.Management.Service.Data_Access_Layer__DAL_.Models;

namespace BussinessLayer;

    public class AuthenticationService : IAuthenticationService
    {
    public UserManager<Employee_Model> EmployeeManager { get; }
    public UserManager<Compuny_Model> CompunyManager { get; }
    public UserManager<UserModel> UserManager { get; }
    public RoleManager<IdentityRole> RoleManager { get; }
    public IConfiguration Configuration { get; }

    public AuthenticationService(UserManager<Employee_Model> employeeManager, UserManager<Compuny_Model> compunyManager ,
        RoleManager<IdentityRole> roleManager, UserManager<UserModel> userManager , IConfiguration configuration)
    {
        EmployeeManager = employeeManager;
        CompunyManager = compunyManager;
        UserManager = userManager;
        RoleManager = roleManager;
        Configuration = configuration;
    }





    public async  Task<Response> Employee_Register( Register_Model Model)
    {

        var test = await UserManager.FindByNameAsync(Model.Username);
        var User_Exists = await EmployeeManager.FindByNameAsync(Model.Username);
        if (User_Exists != null)

            return  new Response { Status = "Error", Message = "The User Already Exist " };


        Employee_Model user = new()
        {
            Email = Model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = Model.Username


        };
        var result = await EmployeeManager.CreateAsync(user, Model.Password);


        if (!result.Succeeded)
        {
            string ErrorsMassege = string.Join("\n", result.Errors.Select(e => e.Description));


            Response Response = new Response() { Status = "Error", Message = ErrorsMassege };

            return  Response;
        }

        await  User_Add_Role(UserRoles.Employee, user);


        return new Response { Status = "Success", Message = "User created successfully!" };


    }


    public async Task< Response> Compuny_Register( Register_Model Model)
    
    {
        var userExists = await CompunyManager.FindByNameAsync(Model.Username);
        if (userExists != null)
            return new Response { Status = "Error", Message = "User already exists!" };

        Compuny_Model user = new()
        {
            Email = Model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = Model.Username
        };
        var result = await CompunyManager.CreateAsync(user, Model.Password);
        if (!result.Succeeded)
        {
            string ErrorsMassege = string.Join("\n", result.Errors.Select(e => e.Description));


            Response Response = new Response() { Status = "Error", Message = ErrorsMassege };

            return Response;
        }

        await  User_Add_Role(UserRoles.Compuny, user);
       
        return new Response { Status = "Success", Message = "User created successfully!" };

    }



    //public async Task<TokenDto> Login(Login_Model Model)
    //{
    //    var userFromEmployee = (IdentityUser)(await EmployeeManager.FindByNameAsync(Model.Username));
    //    var userFromCompany = (IdentityUser)(await CompunyManager.FindByNameAsync(Model.Username));

    //    var User = ((userFromCompany ?? userFromEmployee));
    //    if (User != null && await UserManager.CheckPasswordAsync(User, Model.Password))
    //    {
    //        var UserRoles = await UserManager.GetRolesAsync(User);

    //        // Assign Claims To Logged User 
    //        var authClaims = new List<Claim>
    //            {
    //                new Claim(ClaimTypes.Name, User.UserName),
    //                new Claim(ClaimTypes.Email , User.Email)
    //            };

    //        // Assign All Roles In dataBase THat Related TO THe Logged User in Claims 

    //        foreach (var userRole in UserRoles)
    //        {
    //            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
    //        }

    //        var token = GetToken(authClaims);

    //        return new TokenDto()
    //        {
    //            Token = new JwtSecurityTokenHandler().WriteToken(token),
    //            Expiration = token.ValidTo
    //        };
    //    }
    //    return null;

    //}






    private async Task User_Add_Role (string User_Role , IdentityUser user)
    {

        //if (!await RoleManager.RoleExistsAsync(UserRoles.Compuny))
        //    await RoleManager.CreateAsync(new IdentityRole(UserRoles.Compuny));
        //if (!await RoleManager.RoleExistsAsync(UserRoles.Employee))
        //    await RoleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

        //if (await RoleManager.RoleExistsAsync(User_Role))
        //{
        //    await EmployeeManager.AddToRoleAsync(user, User_Role);
        //    await CompunyManager.AddToRoleAsync(user, User_Role);
        //}

        // Check if the user is of type ApplicationUser1
        if (user is Employee_Model user1)
        {
            // Check if the role exists and add it to the user
            if (!await RoleManager.RoleExistsAsync(UserRoles.Employee))
                await RoleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

            if (await RoleManager.RoleExistsAsync(User_Role))
            {
                await EmployeeManager.AddToRoleAsync(user1, User_Role);
            }
        }
        // Check if the user is of type ApplicationUser2
        else if (user is Compuny_Model user2)
        {
            if (!await RoleManager.RoleExistsAsync(UserRoles.Compuny))
                await RoleManager.CreateAsync(new IdentityRole(UserRoles.Compuny));
            if (await RoleManager.RoleExistsAsync(User_Role))
            {
                await CompunyManager.AddToRoleAsync(user2, User_Role);
            }
        }
        // 


    }



    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}

