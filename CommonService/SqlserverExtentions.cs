using CommonService.DatabaseLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using CommonService.Configurations;

namespace CommonService
{
    public static class SqlserverExtentions
    {
        
        public static IServiceCollection AddSqlServerDataBase<TContext>(this IServiceCollection  services  , IConfiguration configuration) where TContext : DbContext
        {

             services.Configure<SqlServerSettings>(configuration.GetSection(nameof(SqlServerSettings)));

        var sqlServerSettings = configuration.GetSection(nameof(SqlServerSettings)).Get<SqlServerSettings>();

        // Register SQL Server DbContext (Entity Framework Core) or other SQL Server services here
        services.AddDbContext<TContext>(options =>
            options.UseSqlServer(sqlServerSettings.ConnectionString)
        );

        // Add other SQL Server related services as needed

        return services;
        
        }

        public static IServiceCollection AddIdentityandDependancies<TContext , TIdentityUser , TIdenityRole>(this IServiceCollection Services, IConfiguration configuration)where TContext : DbContext where TIdentityUser : IdentityUser where TIdenityRole : IdentityRole
        {

            //// For Identity
            Services.AddIdentity<TIdentityUser, TIdenityRole>()
                .AddEntityFrameworkStores<TContext>()
                .AddDefaultTokenProviders();

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })


            // add Jwt Bearar 
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateIssuerSigningKey = true,

                };
            });

            #region autherization Region

           Services.AddAuthorization(options =>
            {
                options.AddPolicy("Employee", policy => policy
                    .RequireClaim(ClaimTypes.Role, UserRoles.Employee)
                    .RequireClaim(ClaimTypes.NameIdentifier));
                
                options.AddPolicy("Compuny", policy => policy
                    .RequireClaim(ClaimTypes.Role, UserRoles.Compuny)
                    .RequireClaim(ClaimTypes.NameIdentifier));    
                options.AddPolicy("Admin", policy => policy
                    .RequireClaim(ClaimTypes.Role, UserRoles.Admin)
                    .RequireClaim(ClaimTypes.NameIdentifier));

            });
            #endregion 

            return Services;
        }




    }
}
