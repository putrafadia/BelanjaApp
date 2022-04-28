using BelanjaAppIdentityServer.Helpers;
using BelanjaAppIdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BelanjaAppIdentityServer.BelanjaApp.Data
{
    public class UserRepository : IUser
    {
        private UserManager<IdentityUser> _usermanager;
        private AppSettings _appSettings;

        public UserRepository(UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            _usermanager = userManager;
            _appSettings = appSettings.Value;
        }
        public async Task<UserViewModels> Authenticate(string username, string password)
        {
            var curnUser = await _usermanager.FindByNameAsync(username);
            var userResult = await _usermanager.CheckPasswordAsync(curnUser, password);
            if (!userResult)
            {
                throw new Exception($"Authentikasi Gagal");
            }
            var user = new UserViewModels
            {
                UserName = username,
            };

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public IEnumerable<UserViewModels> GetAllUsers()
        {
            var users = new List<UserViewModels>();
            foreach (var user in _usermanager.Users)
            {
                users.Add(new UserViewModels { UserName = user.UserName });
            }
            return users;
        }

        public async Task Registration(UserCreateViewModels createUser)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = createUser.UserName,
                    Email = createUser.UserName
                };
                var result = await _usermanager.CreateAsync(newUser, createUser.Password);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    var errors = result.Errors;
                    foreach (var error in errors)
                    {
                        sb.Append($"{error.Code} - {error.Description}");
                    }
                    throw new Exception($"error : {sb.ToString()}");
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"error : {ex.Message}");
            }
        }
    }
}
