using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using CustomerAPI.Core.Interface.Repository.User;
using CustomerAPI.Core.Model.AppSettings;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Core.Model.Authorization;
using CustomerAPI.Core.Interface.Service.Authorization;
using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Service.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly JWTOption _jwtOption;
        private readonly IUserSysRepository _userSysRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public AuthorizationService(IUserSysRepository userSysRepository,
                                    IUserRoleRepository userRoleRepository,
                                    JWTOption jwtOption)
        {
            _userSysRepository = userSysRepository;
            _userRoleRepository = userRoleRepository;
            _jwtOption = jwtOption;
        }

        public BaseResult<AuthorizationToken> Authenticate(UserLogin userLogin)
        {
            try
            {
                var user = _userSysRepository.GetByLoginAndPassword(userLogin);

                if (user == null)
                    throw new UnauthorizedException("The email and/or password entered is invalid. Please try again.");

                var token = GenerateToken(user);
                var refreshToken = GenerateRefreshToken();

                var authorizationToken = new AuthorizationToken {
                    Token = token,
                    RefreshToken = refreshToken.Token,
                    User = user
                };

                return BaseResult<AuthorizationToken>.OK(authorizationToken);
            }
            catch (Exception e)
            {
                return BaseResult<AuthorizationToken>.NotOK(e.Message);
            }
        }

        private string GenerateToken(UserSys user)
        {
            /*try
            {*/
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOption.SecretKey));
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login.ToString())
                };

                var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(_jwtOption.ExpirationMinutes),
                    SigningCredentials = credencials
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            /*}
            catch (Exception e)
            {
                throw new Badre
            }*/
        }

        private RefreshToken GenerateRefreshToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddMinutes(_jwtOption.ExpirationMinutes),
                    Created = DateTime.UtcNow
                };
            }
        }
    }
}
