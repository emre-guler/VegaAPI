using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vega.Data;
using Vega.DTO;
using Vega.Entities;
using Vega.Enums;
using Vega.Interfaces;

namespace Vega.Services
{
    public class JwtService : IJwtService
    {
        private readonly VegaContext _db;
        private IConfiguration Configuration { get; }
        public JwtService(VegaContext db, IConfiguration configuration)
        {
            _db = db;
            Configuration = configuration;
        }

        public string Create (User user)
        {
            SymmetricSecurityKey secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecureKey"]));
            SigningCredentials credentials = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256Signature);
            
            List<Claim> claims = new() 
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Role.ToString())
            };

            JwtSecurityToken token =  new JwtSecurityToken (
                issuer: Configuration["Jwt:SecureKey"],
                audience: Configuration["Jwt:SecureKey"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            string encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            
            return encodedToken;
        }

        public JwtClaimDto ReadToken(ClaimsIdentity claims)
        {
            try
            {
                var claimsList = claims.Claims.ToList();
                if (claimsList.Count() != 0)
                {
                    JwtClaimDto jwtData = new()
                    {
                        Id = int.Parse(claimsList[0].Value),
                        Role = (Role) int.Parse(claimsList[1].Value)
                    };

                    return jwtData;
                }
                
                return null;
            }
            catch(Exception e)
            {
                Console.Write(e);
            }

            return null;
        }
    }
}