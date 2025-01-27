using Microsoft.EntityFrameworkCore;
using UserWalletAPI.ApiServices;
using UserWalletAPI.Data;
using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Repositories;
using UserWalletAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserApiService, UserApiService>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IWalletApiService, WalletApiService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
