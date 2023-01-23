using Ikk.Claims.Common;
using IKK.Claims.Application.Common;
using IKK.Claims.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUserService
    {
        private readonly IClaimDbContext _context;

        public GetUserService(IClaimDbContext context)
        {
            _context = context;
        }

        public ResultGetUsers Execute(RequestDto request)
        {
            var result = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                result = result.Where(p => p.UserName.Contains(request.SearchKey));
            }
            var rows = result.Count();
            return new ResultGetUsers
            {
                RowCount = rows,
                users = result.ToPaged(request.Page, 20, out rows).Select(p => new GetUsersDto
                {
                    UserName = p.UserName,
                    Id = p.Id
                }).ToList()
            };
        }
    }

}
