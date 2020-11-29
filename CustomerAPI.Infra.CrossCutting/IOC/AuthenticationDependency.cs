using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using CustomerAPI.Core.Model.AppSettings;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CustomerAPI.Infra.CrossCutting.IOC
{
    public static class AuthenticationDependency
    {
        public static void AddAuthenticationDependency(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("JWT");

            services.Configure<JWTOption>(appSettingsSection)
                    .AddSingleton(sp => sp.GetRequiredService<IOptions<JWTOption>>().Value);

            var jwtOption = appSettingsSection.Get<JWTOption>();
            var key = Encoding.ASCII.GetBytes(jwtOption.SecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                        //ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddMvc(o => 
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    o.Filters.Add(new AuthorizeFilter(policy));
                });
        }
    }
}
