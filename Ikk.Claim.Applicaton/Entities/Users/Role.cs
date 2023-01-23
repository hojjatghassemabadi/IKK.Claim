using Ikk.Claim.Domain.Commons;
using Ikk.Claim.Domain.Commons.Statics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ikk.Claim.Domain.Entities.Users
{

    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
