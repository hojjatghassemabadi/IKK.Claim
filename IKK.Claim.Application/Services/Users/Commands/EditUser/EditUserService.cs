using IKK.Claim.Application.Common;
using IKK.Claim.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claim.Application.Services.Users.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IClaimDbContext _context;

        public EditUserService(IClaimDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditUserDto request)
        {
            var result = _context.Users.Find(request.Id);
            if (result == null)
            {
                return new ResultDto { IsSuccess = false, Message = "کاربر مورد نظر پیدا نشد" };
            }
            result.UserName = request.UserName;
            result.Password=request.Password;
            result.Status = request.Status;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت بروز شد"
            };
        }
    }
}
