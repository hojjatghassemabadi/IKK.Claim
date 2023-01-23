namespace IKK.Claim.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
        public List<RoleINRegisterUserDto> roles { get; set; }

    }
}
