using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using PandosAPI.Identity;
using PandosAPI.Models;

var MyAllowSpecificOrigins = "AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// NOTE builder.Services is what was called ConfigureServices() in dotnet 5
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<proteindomainannotationsContext>(options =>
{
    options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect((defaultConnectionString)));
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(identityConnectionString, ServerVersion.AutoDetect((identityConnectionString)));
});


// builder.Services.AddDbContext<proteindomainannotationsContext>(options =>
//    options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString));

// could be renamed IdentityDbContext but that's a stretch goal
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySql(identityConnectionString));


// where rules like password limitations are created... can make anon function opt to pass other arguments
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,



            ValidIssuer = "http://localhost:5000",
            ValidAudience = "http://localhost:5000",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("protein-domain-annotations@8:59PMS#cretKey"))

        };
    });

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PandosAPI", Version = "v1" });

        OpenApiSecurityScheme jwtSecurityScheme = new()
        {
            Scheme = "bearer",
            BearerFormat = "JWT",
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Description = "Put ** _ONLY_ ** your JWT Bearer token on the textbox below!",

            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };
        c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { jwtSecurityScheme, Array.Empty<string>() }
        });
    });

// builder.Services.AddAuthentication()
//    .AddIdentityServerJwt();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com",
                                              "http://www.contoso.com")
                                              .AllowAnyOrigin()
                                              .AllowAnyHeader()
                                              .AllowAnyMethod()
                                              .SetIsOriginAllowed(_ => true);
                      });
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

app.UseHttpsRedirection();


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
