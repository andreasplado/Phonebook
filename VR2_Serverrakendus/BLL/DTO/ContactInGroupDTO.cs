using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ContactInGroupDTO
    {
        public int ContactInGroupId { get; set; }

        public int ContactId { get; set; }

        public int GroupId { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Deleted { get; set; }

        public DateTime? Updated { get; set; }

    }
}
