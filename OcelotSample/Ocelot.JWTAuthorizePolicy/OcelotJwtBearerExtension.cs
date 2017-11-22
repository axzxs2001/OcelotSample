using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocelot.JWTAuthorizePolicy
{
    /// <summary>
    /// Ocelot下JwtBearer扩展
    /// </summary>
    public static class OcelotJwtBearerExtension
    {
        /// <summary>
        /// 注入Ocelot下JwtBearer
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="issuer">发行人</param>
        /// <param name="audience">订阅人</param>
        /// <param name="secret">密钥</param>
        /// <param name="defaultScheme">默认架构</param>
        /// <param name="isHttps">是否https</param>
        /// <returns></returns>
        public static AuthenticationBuilder AddOcelotJwtBearer(this IServiceCollection services, string issuer, string audience, string secret, string defaultScheme, bool isHttps = false)
        {
            var keyByteArray = Encoding.ASCII.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = issuer,//发行人
                ValidateAudience = true,
                ValidAudience = audience,//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };
            return services.AddAuthentication(options =>
            {
                options.DefaultScheme = defaultScheme;
            })
             .AddJwtBearer(defaultScheme, opt =>
             {
                 //不使用https
                 opt.RequireHttpsMetadata = isHttps;
                 opt.TokenValidationParameters = tokenValidationParameters;
             });
        }
    }
}
