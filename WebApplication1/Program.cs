using UserWalletAPI.ApiServices;
using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserApiService, UserApiService>();
builder.Services.AddSingleton<IWalletService, WalletService>();
builder.Services.AddSingleton<IWalletApiService, WalletApiService>();

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
