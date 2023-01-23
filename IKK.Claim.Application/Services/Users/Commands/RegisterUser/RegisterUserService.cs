using Ikk.Claims.Domain.Entities.Users;
using IKK.Claims.Application.Common;
using IKK.Claims.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IClaimDbContext _context;

        public RegisterUserService(IClaimDbContext context)
        {
            _context = context;
        }

        ResultDto<ResultRegisterUserDto> IRegisterUserService.Execute(RequestRegisterUserDto request)
        {
            User user = new User
            {
                UserName = request.UserName,
                Password = request.Password
            };
            List<UserInRole> userInRoles = new List<UserInRole>();
            foreach(var item in request.roles)
            {
                var roles = _context.Roles.Find(item.Id);
                userInRoles.Add(new UserInRole
                {
                    Role=roles,
                    RoleId=roles.Id,
                    User=user,
                    UserId=user.Id
                });
            }
            user.UserInRoles = userInRoles;
            _context.Users.Add(user);
            _context.SaveChanges();
            return new ResultDto<ResultRegisterUserDto>
            {
                IsSuccess = true,
                Message = "باموفقیت ثبت شد",
                Data = new ResultRegisterUserDto
                {
                    UserId = user.Id
                }
            };
        }
    }
}
