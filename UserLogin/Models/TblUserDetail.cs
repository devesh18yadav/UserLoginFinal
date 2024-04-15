using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public partial class TblUserDetail
    {
        [Key]
        public int MobileNum { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? EmailId { get; set; }
        
        public Byte[]? DisplayImage { get; set; }
    }
}
