using Microsoft.OpenApi.Models;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Helpers.Interface;
using StudentManagementSystem.Operation;
using StudentManagementSystem.Operation.Interface;
using StudentManagementSystem.Repository;
using StudentManagementSystem.Repository.Interface;

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
    
   services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentManagementSystem", Version = "v1" });
    });

}


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
