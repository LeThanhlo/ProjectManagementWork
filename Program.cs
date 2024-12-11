using Container_App.Data;
using Container_App.Repository.AuthRepository;
using Container_App.Repository.ProjectRepository;
using Container_App.Repository.ProjectUserInviteRepository;
using Container_App.Repository.ProjectUserRepository;
using Container_App.Repository.UserRepository;
using Container_App.Services.AuthService;
using Container_App.Services.ProjectService;
using Container_App.Services.UserService;
using Container_App.utilities;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString));
#endregion

#region Add Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectUserRepository, ProjectUserRepository>();
builder.Services.AddScoped<IProjectUserInviteRepository, ProjectUserInviteRepository>();
builder.Services.AddScoped<SqlQueryHelper>();
builder.Services.AddScoped<Config>();
#endregion

#region Add Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
#endregion


//var jwtSecretKey = "BECA4125763BA46B43FA472D96CEB";
var jwtSecretKey = "ThisIsAStrongSecretKey1234567890!";
builder.Configuration["JWT_SECRET_KEY"] = jwtSecretKey;
if (string.IsNullOrEmpty(jwtSecretKey))
{
    throw new InvalidOperationException("JWT_SECRET_KEY must be set in the .env file.");
}
var key = Encoding.UTF8.GetBytes(jwtSecretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Cấu hình ứng dụng lắng nghe HTTP
builder.WebHost.UseUrls("http://localhost:5295");

var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // Đặt trước UseRouting // bỏ chạy http thâu
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Không cần gọi MapControllers ở đây
});

app.Run();
