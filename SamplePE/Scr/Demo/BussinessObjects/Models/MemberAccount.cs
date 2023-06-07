using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObjects.Models
{
    public partial class MemberAccount
    {
        public string MemberId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MemberPassword { get; set; }
        public int? MemberRole { get; set; }
    }
}
