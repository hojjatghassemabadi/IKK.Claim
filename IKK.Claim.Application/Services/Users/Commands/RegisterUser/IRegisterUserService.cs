using IKK.Claim.Application.Common;

namespace IKK.Claim.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);    
    }
}
