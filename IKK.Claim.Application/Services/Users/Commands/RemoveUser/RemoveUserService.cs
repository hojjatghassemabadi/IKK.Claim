using IKK.Claims.Application.Common;
using IKK.Claims.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IClaimDbContext _context;

        public RemoveUserService(IClaimDbContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long Id)
        {
            var result = _context.Users.Find(Id);
            if (result == null)
            {
                return new ResultDto { IsSuccess = false , Message="کاربر مورد نظر پیدا نشد"};
            }
            result.IsRemoved = true;
            result.DateRemoved = DateTime.Now;
            result.RemovedBy = 1;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر مورد نظر با موفقیت حذف شد."
            };
        }
    }
}
