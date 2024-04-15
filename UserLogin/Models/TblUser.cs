using System;
using System.Collections.Generic;

namespace UserLogin.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
