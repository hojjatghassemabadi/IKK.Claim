using IKK.Claims.Application.Common;
using IKK.Claims.Application.Interfaces.FacadPatterns;
using IKK.Claims.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace IKK.Claim.Presentation.Controllers
{
    [ApiController]
    public class ClaimController: ControllerBase
    {
        private readonly IUsersFacad _userService;

        public ClaimController(IUsersFacad userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ResultGetUsers GetUsers(RequestDto requsetDto) {
            var result=_userService.GetUserService.Execute(requsetDto);
            return result;
        } 
    }
}
