using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer;

public class GoogleService: IGoogleService
{



    #region  Attrebutes & Dependancy Enjiction 



    private readonly IConfiguration _Configuration;
    private string ClientId => _Configuration.GetSection("Google:ClientId").Value;
    private string SecretKey => _Configuration.GetSection("Google:SecretKey").Value;
    private string RedirectUrl=> _Configuration.GetSection("Google:RedirectUrl").Value;

    public IHttpContextAccessor HttpContextAccessor { get; }


    #endregion



    public GoogleService(IConfiguration Configuration , IHttpContextAccessor httpContextAccessor )
    {
        _Configuration = Configuration;
        HttpContextAccessor = httpContextAccessor;
    }




    /// <summary>
    ///  Step 1 Hit the Google EndPoint To Force User Enter his Email And  Get the Autherization Code In Url  
    /// </summary>

    public void LoginUsingGoogle()
    {
        var Response = HttpContextAccessor.HttpContext.Response;

        Response.Redirect($"https://accounts.google.com/o/oauth2/auth?client_id={ClientId}&response_type=code&scope=openid%20email%20profile&redirect_uri={RedirectUrl}");
    }


    /// <summary>
    ///  Step 2 Handle The Response Exchange Code By Token 
    /// </summary>
    /// <param name="Code"></param>
    /// <param name="State"></param>
    /// <param name="SissionState"></param>
    /// <returns></returns>
    public  async Task< UserProfile> HandleGoogleResponse(string Code , string State = null  , string SissionState = null)
    {
         var httpClient = new HttpClient  
            {  
                BaseAddress = new Uri("https://www.googleapis.com")  
            };

        var requestUrl = $"oauth2/v4/token?code={Code}&client_id={ClientId}&client_secret={SecretKey}&redirect_uri={RedirectUrl}&grant_type=authorization_code";

        var dict = new Dictionary<string, string>
            {
                { "Content-Type", "application/x-www-form-urlencoded" }
            };
        var req = new HttpRequestMessage(HttpMethod.Post, requestUrl) { Content = new FormUrlEncodedContent(dict) };
        var response = await httpClient.SendAsync(req);
        var token = JsonConvert.DeserializeObject<GmailToken>(await response.Content.ReadAsStringAsync());
       var User = token.AccessToken;
        var Object = await GetuserProfile(token.AccessToken);

        //IdToken property stores user data in Base64Encoded form  
        //var data = Convert.FromBase64String(token.IdToken.Split('.')[1]);  
        //var base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);  

        return Object;
    }




    /// <summary>  
    /// To fetch User Profile by access token  Step 3 
    /// </summary>  
    /// <param name="accesstoken">access token</param>  
    /// <returns>User Profile page</returns>  
    public async Task<UserProfile> GetuserProfile(string accesstoken)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.googleapis.com")
        };
        string url = $"https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token={accesstoken}";
        var response = await httpClient.GetAsync(url);
        return JsonConvert.DeserializeObject<UserProfile>(await response.Content.ReadAsStringAsync());
    }


}  











