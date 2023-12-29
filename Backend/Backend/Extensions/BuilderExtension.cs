using Backend.DataAccess.UnitOfWork;
using Backend.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Backend.Extensions
{
    public static class BuilderExtension
    {
        public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(
                    "AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });
            return builder;
        }

            public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hLZlqC5HqT2QXMChbXr9rIvI8Vl9u1O4nv49j6k-2Zw")),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true
                });

            builder.Services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(opt =>
                {
                    opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                    {
                        In = ParameterLocation.Header,
                        Name = HeaderNames.Authorization,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                    opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        [new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = JwtBearerDefaults.AuthenticationScheme,
                                Type = ReferenceType.SecurityScheme
                            }
                        }] = Array.Empty<string>()
                    });
                });
            return builder;
        }

        public static WebApplicationBuilder AddGrpc(this WebApplicationBuilder builder)
        {
            builder.Services.AddGrpc(opt => opt.EnableDetailedErrors = true);
            builder.Services.AddGrpcReflection();
            return builder;
        }

        public static WebApplicationBuilder AddConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<LoanDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("LoanDb")));
            builder.Services.AddControllers();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            
            return builder;
        }
    }
}
