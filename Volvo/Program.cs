using Business.Abstract;
using Business.Concrete;
using Core.Security.Hashing;
using Core.Security.TokenHandler;
using DataAccesss.Abstract;
using DataAccesss.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<IBusDal, BusDal>();
builder.Services.AddScoped<IBusManager, BusManager>();

builder.Services.AddScoped<IPartDal, PartDal>();
builder.Services.AddScoped<IPartManager, PartManager>();

builder.Services.AddScoped<IAuthDal, AuthDal>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddScoped<IRoleDal, RoleDal>();
builder.Services.AddScoped<IRoleMananger, RoleManager>();

builder.Services.AddScoped<IUserRoleDal, UserRoleDal>();
builder.Services.AddScoped<IUserRoleManager, UserRoleManager>();

builder.Services.AddScoped<IFeedbackDal,FeedbackDal>();
builder.Services.AddScoped<IFeedbackManager, FeedbackManager>();

builder.Services.AddScoped<HashingHandler>();

builder.Services.AddScoped<TokenGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
