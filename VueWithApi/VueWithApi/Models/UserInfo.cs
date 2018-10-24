using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueWithApi.Models
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
