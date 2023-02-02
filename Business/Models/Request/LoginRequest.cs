using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request
{
    public class LoginRequest
    {
        public string? name { get; set; }
        public string? email { get; set; }
    }
}
