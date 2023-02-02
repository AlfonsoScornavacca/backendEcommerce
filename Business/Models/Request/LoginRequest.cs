using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request
{
    public class LoginRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
