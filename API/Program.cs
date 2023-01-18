using API.Jobs;
using API.Middleware;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddInjections();

IConfiguration _configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connString);
builder.Services.AddDbContext<HangfireExampleDbContext>(
                options => options.UseSqlServer(connString)); builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHangfire(x => x.UseSqlServerStorage(_configuration.GetSection("HangfireSettings:DefaultConnection").Value));
builder.Services.AddHangfireServer();


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
app.UseHangfireDashboard("/job", new DashboardOptions
{
    Authorization = new[]
{
    new HangfireCustomBasicAuthenticationFilter
    {
         User = _configuration.GetSection("HangfireSettings:UserName").Value,
         Pass = _configuration.GetSection("HangfireSettings:Password").Value
    }
    }
});
app.UseHangfireServer(new BackgroundJobServerOptions());

RecurringJobs.HangfireJob();

app.Run();
