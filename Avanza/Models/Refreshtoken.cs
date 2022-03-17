using System;
using System.Collections.Generic;

namespace Avanza.Models
{
    public partial class Refreshtoken
    {
        public string UserId { get; set; }
        public string TokenId { get; set; }
        public string RefreshToken1 { get; set; }
        public bool? IsActive { get; set; }
    }
}
