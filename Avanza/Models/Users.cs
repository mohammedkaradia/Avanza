using System;
using System.Collections.Generic;

namespace Avanza.Models
{
    public partial class Users
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int? JobId { get; set; }
    }
}
