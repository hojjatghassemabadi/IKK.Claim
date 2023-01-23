using Ikk.Claim.Domain.Commons.Statics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ikk.Claim.Domain.Entities.Users
{

    public class UserInRole {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
