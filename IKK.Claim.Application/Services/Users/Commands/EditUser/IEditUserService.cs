using IKK.Claim.Application.Common;

namespace IKK.Claim.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEditUserDto request);
    }
}
