using IKK.Claims.Application.Common;
using IKK.Claims.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Services.Users.Commands.UserStatusChange
{
    public class UserStatusChangeService : IUserStatusChangeService
    {
        private readonly IClaimDbContext _context;

        public UserStatusChangeService(IClaimDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long Id)
        {
            var result = _context.Users.Find(Id);
            if(result == null)
            {
                return new ResultDto { IsSuccess = false,Message="کاربر مورد نظر پیدا نشد" };
            }
            result.Status = !result.Status;
            _context.SaveChanges();
            string userchange = result.Status == true ? "فعال" : "غیرفعال";
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userchange} شد"
            };

                
        }
    }
}
