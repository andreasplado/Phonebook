using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ContactInGroup
    {
        public int ContactInGroupId { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Deleted { get; set; }

        public DateTime? Updated { get; set; }


        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

    }
}
