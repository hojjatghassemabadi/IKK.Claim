using IKK.Claims.Application.Common;

namespace IKK.Claims.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEditUserDto request);
    }
}
