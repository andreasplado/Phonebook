using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ContactId { get; set; }

        [MaxLength(128)]
        public string ContactName { get; set; }

        [MaxLength(128)]
        public string ContactLastName{ get; set; }

        [MaxLength(128)]
        public string ContactValue { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Deleted { get; set; }

        public DateTime? Updated { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }


        public virtual List<ContactType> ContactTypes { get; set; }

        public virtual List<ContactInGroup> ContactInGroups { get; set; } 
    }
}
