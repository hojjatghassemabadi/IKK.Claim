using IKK.Claim.Application.Common;

namespace IKK.Claim.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long Id);
    }
}
