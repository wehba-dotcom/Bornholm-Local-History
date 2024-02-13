using IdentityApi.Data;
using IdentityApi.Models;
using IdentityApi.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(ApplicationDbContext db, IJwtTokenGenerator jwtTokenGenerator,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
                _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //create role if it does not exist
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;

        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user,loginRequest.Password);

            if(user==null || isValid == false)
            {
                return new LoginResponse() { User = null,Token="" };
            }

            //if user was found , Generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user,roles);

            User userDTO = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponse loginResponse = new LoginResponse()
            {
                User = userDTO,
                Token = token
            };

            return loginResponse;
        }

        public async Task<string> Register(RegistrationRequest registrationRequest)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequest.Email,
                Email = registrationRequest.Email,
                NormalizedEmail = registrationRequest.Email.ToUpper(),
                Name = registrationRequest.Name,
                PhoneNumber = registrationRequest.PhoneNumber
            };

            try
            {
                var result =await  _userManager.CreateAsync(user,registrationRequest.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.Users.First(u => u.UserName == registrationRequest.Email);

                    User userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";

                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {

            }
            return "Error Encountered";
        }
    }
}
