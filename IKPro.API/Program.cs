using IKPro.Application.Mapper;
using IKPro.Application.Services.LoginServis;
using IKPro.Application.Services.MailServis;
using IKPro.Application.Services.PaketServis;
using IKPro.Application.Services.PersonelServis;
using IKPro.Application.Services.SirketServis;
using IKPro.Application.Services.SirketYoneticiServis;
using IKPro.Application.Services.SiteYoneticiServis;
using IKPro.Application.Services.TalepFormServis;
using IKPro.Application.Services.TokenServis;
using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Data;
using IKPro.Infrastructure.Repositories.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IKProDbContext>(x => x.UseSqlServer());

builder.Services.AddIdentity<AppUser, AppRole>(x => x.SignIn.RequireConfirmedEmail = false)
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<IKProDbContext>()
                .AddDefaultTokenProviders(); 



var jwtSettings = builder.Configuration.GetSection("JwtSettings");

var secretKey = jwtSettings["secretKey"];
builder.Services.AddAuthentication(x =>
{ x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(y => { y.SaveToken = true;
    y.RequireHttpsMetadata = false;
    y.TokenValidationParameters=new TokenValidationParameters { ValidateActor= false, ValidateAudience=false, IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) };
});                    


//IoC => Automapper
builder.Services.AddAutoMapper(typeof(Mapper));



//IoC => Services and Repositories
builder.Services.AddScoped<ITokenServis, TokenServis>();
builder.Services.AddScoped<ILoginServis, LoginServis>();

builder.Services.AddScoped<IPaketServis, PaketServis>();
builder.Services.AddScoped<IPaketRepository, PaketRepository>();

builder.Services.AddScoped<ISirketServis, SirketServis>();
builder.Services.AddScoped<ISirketRepository, SirketRepository>();

builder.Services.AddScoped<ISirketYoneticiServis, SirketYoneticiServis>();
builder.Services.AddScoped<ISiteYoneticiServis, SiteYoneticiServis>();
builder.Services.AddScoped<IPersonelServis, PersonelServis>();

builder.Services.AddScoped<IIzinTalepServis, IzinTalepServis>();
builder.Services.AddScoped<IIzinTalepRepository, IzinTalepRepository>();

builder.Services.AddScoped<IHarcamaTalepServis, HarcamaTalepServis>();
builder.Services.AddScoped<IHarcamaTalepRepository, HarcamaTalepRepository>();

builder.Services.AddScoped<IAvansTalepServis, AvansTalepServis>();
builder.Services.AddScoped<IAvansTalepRepository, AvansTalepRepository>();

builder.Services.AddScoped<IEmailGondericiServis, EmailGondericiServis>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        //policy.WithOrigins("http://localhost:5173") // Ýzin verilen frontend adresi
        //      .AllowAnyHeader() // Tüm header'lara izin ver
        //      .AllowAnyMethod() // GET, POST, PUT, DELETE gibi tüm HTTP metodlarýna izin ver
        //      .AllowCredentials(); // Kimlik doðrulama baþlýklarýna izin ver
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin() // React uygulamanýzýn URL'si
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });

    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    }); ;
}

app.UseRouting();

app.UseCors(/*"AllowFrontend",*/ opt =>
{
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
    opt.AllowAnyOrigin();
}); // ************
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();

