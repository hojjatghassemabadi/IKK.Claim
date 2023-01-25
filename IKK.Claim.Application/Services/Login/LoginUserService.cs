using IKK.Claims.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Services.Login
{
    public interface ILoginUserService{
        LoginUserResultDto Execute(LoginUserRequestDto request);
    }
    public class LoginUserRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserResultDto
    {
        public bool IsSuccess { get; set; }
        public string UserName { get; set; }
    }
    public class LoginUserService : ILoginUserService
    {
        private readonly IClaimDbContext _context;

        public LoginUserService(IClaimDbContext context)
        {
            _context = context;
        }
        public LoginUserResultDto Execute(LoginUserRequestDto request)
        {
            if(string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginUserResultDto
                {
                    IsSuccess = false,
                    UserName = null
                };

            }
            var result=_context.Users.Where(x => x.UserName == request.UserName && x.Password==request.Password);
            if (result.Count()<=0)
            {
                return new LoginUserResultDto
                {
                    IsSuccess = false,
                    UserName = null
                };
            }
            else
            {
                return new LoginUserResultDto
                {
                    IsSuccess = true,
                    UserName = request.UserName
                };
            }
        }
    }
}
