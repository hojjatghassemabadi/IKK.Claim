using IKK.Claims.Application.Common;

namespace IKK.Claims.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long Id);
    }
}
