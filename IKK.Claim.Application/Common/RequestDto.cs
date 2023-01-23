using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claim.Application.Common
{
    public class RequestDto
    {
        public string SearchKey { get; set; }
        public int Page { get; set; } = 1;
    }
}
