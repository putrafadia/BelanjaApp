using BelanjaAppIdentityServer.BelanjaApp.Data;
using BelanjaAppIdentityServer.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add EF
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("IdentityConnection")
    ));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUser, UserRepository>();

//jwt token
var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);
var appSetings = appSettingSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSetings.secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
});

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



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
