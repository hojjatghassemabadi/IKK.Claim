namespace IKK.Claim.Application.Services.Users.Commands.EditUser
{
    public class RequestEditUserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
