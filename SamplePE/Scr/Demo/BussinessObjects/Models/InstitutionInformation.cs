using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObjects.Models
{
    public partial class InstitutionInformation
    {
        public InstitutionInformation()
        {
            CorrespondingAuthors = new HashSet<CorrespondingAuthor>();
        }

        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string TelephoneNumber { get; set; }
        public string InstitutionDescription { get; set; }

        public virtual ICollection<CorrespondingAuthor> CorrespondingAuthors { get; set; }
    }
}
