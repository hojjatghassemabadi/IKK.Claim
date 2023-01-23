using Ikk.Claim.Domain.Commons;
using Ikk.Claim.Domain.Commons.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claim.Domain.Entities.Users
{
    
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; } = true;
        public ICollection<UserInRole> UserInRoles { get; set; }

    }
}
