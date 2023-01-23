namespace IKK.Claim.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUsers
    {
        public int RowCount { get; set; }
        public List<GetUsersDto> users { get; set; }
    }

}
