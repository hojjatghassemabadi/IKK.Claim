using IKK.Claim.Application.Common;

namespace IKK.Claim.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long Id);
    }
}
