using Ikk.Claims.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claims.Application.Interfaces.JwtAuthentication
{
    public interface IJwtAuthenticationManager
    {
        JwtAuthResponse Autentication(string username, string password);
    }
}
