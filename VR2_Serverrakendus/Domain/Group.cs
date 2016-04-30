using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [MaxLength(64)]
        public string GroupName { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Deleted { get; set; }

        public DateTime? Updated { get; set; }

        public virtual List<ContactInGroup> ContactInGroups { get; set; }

    }
}
