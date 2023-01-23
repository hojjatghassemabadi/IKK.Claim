using Ikk.Claims.Domain.Commons;
using Ikk.Claims.Domain.Commons.Statics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ikk.Claims.Domain.Entities.Users
{

    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
