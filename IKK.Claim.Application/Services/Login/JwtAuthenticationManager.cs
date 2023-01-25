using Ikk.Claims.Common;
using IKK.Claims.Application.Interfaces.FacadPatterns;
using IKK.Claims.Application.Interfaces.JwtAuthentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Services.Login
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        public JwtAuthResponse Autentication(string username, string password)
        {
           
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("username", username),
                    new Claim(ClaimTypes.PrimaryGroupSid, "User Group 01")
                }),
                Expires = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityTokens = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityTokens);
            return new JwtAuthResponse
            {
                Token = token,
                UserName = username,
                Expires_in = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
