using IKK.Claim.Application.Common;

namespace IKK.Claim.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        ResultGetUsers Execute(RequestDto request);
    }

}
