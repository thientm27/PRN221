using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObjects.Models
{
    public partial class CorrespondingAuthor
    {
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorBirthday { get; set; }
        public string Bio { get; set; }
        public string Skills { get; set; }
        public int? InstitutionId { get; set; }

        public virtual InstitutionInformation Institution { get; set; }
    }
}
