using IKK.Claims.Application.Common;

namespace IKK.Claims.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);    
    }
}
