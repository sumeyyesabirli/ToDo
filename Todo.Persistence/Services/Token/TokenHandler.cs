using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Todo.Application.Token;

namespace Todo.Persistence.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        Application.Token.Token ITokenHandler.CreateAccessToken(int minute)
        {
            Application.Token.Token token = new();

            //Security Key in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak Token ayarlarını yapıyoruz 
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                 audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow, // üretilen token ne zaman devreye girsin 
                signingCredentials: signingCredentials

                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccsessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
