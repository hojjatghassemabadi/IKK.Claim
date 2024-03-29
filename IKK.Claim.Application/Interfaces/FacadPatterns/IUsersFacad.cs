﻿using IKK.Claims.Application.Services.Login;
using IKK.Claims.Application.Services.Users.Commands.EditUser;
using IKK.Claims.Application.Services.Users.Commands.RegisterUser;
using IKK.Claims.Application.Services.Users.Commands.RemoveUser;
using IKK.Claims.Application.Services.Users.Commands.UserStatusChange;
using IKK.Claims.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Interfaces.FacadPatterns
{
    public interface IUsersFacad
    {
        GetUserService GetUserService { get; }
        EditUserService EditUserService { get; }
        RegisterUserService RegisterUserService { get; }
        UserStatusChangeService UserStatusChangeService { get; }
        RemoveUserService RemoveUserService { get; }
        LoginUserService LoginUserService { get; }

    }
}
