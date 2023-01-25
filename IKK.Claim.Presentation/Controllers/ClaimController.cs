using Ikk.Claims.Common;
using IKK.Claims.Application.Common;
using IKK.Claims.Application.Interfaces.FacadPatterns;
using IKK.Claims.Application.Interfaces.JwtAuthentication;
using IKK.Claims.Application.Services.Login;
using IKK.Claims.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IKK.Claims.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimController: ControllerBase
    {
        private readonly IUsersFacad _userService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public ClaimController(IUsersFacad userService,IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _userService = userService;
        }

      
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm]AuthenticationRequest authenticationRequest)
        {
            var user = _userService.LoginUserService.Execute(new LoginUserRequestDto { UserName = authenticationRequest.UserName, Password = authenticationRequest.Password });
            if (user.IsSuccess == false)
            {
                return Unauthorized();
            }
            var jwtAuthenticationManager=new JwtAuthenticationManager();
            var authResult = _jwtAuthenticationManager.Autentication(authenticationRequest.UserName, authenticationRequest.Password);
            if (authResult == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(authResult);
            }
        }
        [HttpPost]
        [Route("GetUsers")]
        [Authorize]
        public ResultGetUsers GetUsers([FromBody] RequestDto requsetDto)
        {
            var result = _userService.GetUserService.Execute(requsetDto);
            return result;
        }
    }
}
