using Application.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ThirdParties.Authentication
{
    public sealed class JwtProvider : IjwtProvider
    {
        public string Genrate(Account account)
        {
            var claims = new Claim[] 
            {
                new(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new(JwtRegisteredClaimNames.Email,account.Email)
            };
            
            var signinCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwtoptions.SecretKey)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                Jwtoptions.Issuer,
                Jwtoptions.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),//expirationdate
                signinCredentials);
            string tokenvalue = new JwtSecurityTokenHandler()
                .WriteToken(token);
            return tokenvalue;
        }
    }
}
