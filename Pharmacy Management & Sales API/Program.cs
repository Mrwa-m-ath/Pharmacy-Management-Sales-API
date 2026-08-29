using App.Middleware;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;
using Pharmacy_Management___Sales_API.Servies.CategoresServies;
using Pharmacy_Management___Sales_API.Servies.CustomerServices;
using Pharmacy_Management___Sales_API.Servies.ProductsServies;
using Pharmacy_Management___Sales_API.Servies.SaleServies;
using Pharmacy_Management___Sales_API.Servies.UserServies;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwt = builder.Configuration.GetSection("JWT");
var key = Encoding.UTF8.GetBytes(jwt["Key"]!);

builder.Services.Configure<JWT>(
    builder.Configuration.GetSection("JWT")
);

builder.Services.AddDbContext<AppDbContext>(
    s => s.UseSqlServer(
        builder.Configuration.GetConnectionString("FC")
    )
);

builder.Services.AddAutoMapper(s =>
{
}, typeof(Program));

builder.Services.AddScoped<ISUserServies, SUserServies>();
builder.Services.AddScoped<ICategoresServies, CategoresServies>();
builder.Services.AddScoped<IProductsServies, ProductsServies>();
builder.Services.AddScoped<ICustomerServices,  CustomerServices>();
builder.Services.AddScoped<ISaleServies,  SaleServies>();
builder.Services.AddScoped(
    typeof(ISResposter<>),
    typeof(SResposter<>)
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    { 
                options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
       
    });

builder.Services.AddValidation();

builder.Services.AddAuthorization(s=>s.AddPolicy("Admin",p=>p.RequireRole("Admin")));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(s =>
{
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        BearerFormat = "JWT",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();