using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Helpers.Interface;
using StudentManagementSystem.Operation;
using StudentManagementSystem.Operation.Interface;
using StudentManagementSystem.Repository;
using StudentManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StudentManagementSystem.Authentication;
using StudentManagementSystem.Middleware;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddControllers();



    services.AddScoped<IStudentOps, StudentOps>();
    services.AddSingleton<IStudentRepo, StudentRepo>();
    services.AddScoped<IAPIResponseHelper, APIResponseHelper>();
    services.AddScoped<IUserOps, UserOps>();
    services.AddSingleton<IUserRepo, UserRepo>();

    services.AddSwaggerGen(c =>
     {
         c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentManagementSystem", Version = "v1" });
     });

}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = "LectureTest1234$$$";

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSingleton<JwtAuthentication>(new JwtAuthentication(key));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseMiddleware<ResponseTimeMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
