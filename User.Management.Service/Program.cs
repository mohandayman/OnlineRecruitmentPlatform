using BussinessLayer;
using CommonService;
using Microsoft.AspNetCore.Identity;
using User.Management.Service.Data_Access_Layer__DAL_.Context;
using User.Management.Service.Data_Access_Layer__DAL_.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Add Service To COntainer In Data Access Layer (DAL)

builder.Services.AddSqlServerDataBase<UserManagementContext>(builder.Configuration);
builder.Services.AddIdentityandDependancies<UserManagementContext,UserModel , IdentityRole>(builder.Configuration);
builder.Services.AddIdentityandDependancies<UserManagementContext,Employee_Model , IdentityRole>(builder.Configuration);
builder.Services.AddIdentityandDependancies<UserManagementContext,Compuny_Model , IdentityRole>(builder.Configuration);
#endregion
#region  Bussines Layer Services Injection

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<IGoogleService, GoogleService>();

#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
