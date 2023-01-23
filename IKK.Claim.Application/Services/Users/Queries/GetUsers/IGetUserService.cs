using IKK.Claims.Application.Common;

namespace IKK.Claims.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        ResultGetUsers Execute(RequestDto request);
    }

}
