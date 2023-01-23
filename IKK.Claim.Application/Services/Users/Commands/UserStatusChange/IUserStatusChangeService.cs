using IKK.Claims.Application.Common;

namespace IKK.Claims.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long Id);
    }
}
