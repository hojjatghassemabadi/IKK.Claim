using IKK.Claim.Application.Interfaces.Contexts;
using IKK.Claim.Application.Interfaces.FacadPatterns;
using IKK.Claim.Application.Services.Users.Commands.EditUser;
using IKK.Claim.Application.Services.Users.Commands.RegisterUser;
using IKK.Claim.Application.Services.Users.Commands.RemoveUser;
using IKK.Claim.Application.Services.Users.Commands.UserStatusChange;
using IKK.Claim.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claim.Application.Services.Users.FacadPatterns
{
    public class FacadUsers : IUsersFacad
    {
        private readonly IClaimDbContext _context;

        public FacadUsers(IClaimDbContext context)
        {
            _context = context;
        }
        private GetUserService _getUserService;
        public GetUserService GetUserService
        {
            get { return _getUserService=_getUserService??new GetUserService(_context); }
        }
        private EditUserService _editUserService;
        public EditUserService EditUserService {
            get { return _editUserService = _editUserService ?? new EditUserService(_context); }
        }
        private RegisterUserService _registerUserService;
        public RegisterUserService RegisterUserService
        {
            get { return _registerUserService ?? new RegisterUserService(_context); }
        }
        private UserStatusChangeService _userStatusChangeService;
        public UserStatusChangeService UserStatusChangeService
        {
            get { return _userStatusChangeService ?? new UserStatusChangeService(_context); }
        }
        private RemoveUserService _removeUserService;
        public RemoveUserService RemoveUserService
        {
            get { return _removeUserService ?? new RemoveUserService(_context); }
        }
    }
}
