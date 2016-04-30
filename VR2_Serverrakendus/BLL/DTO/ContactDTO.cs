using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ContactDTO
    {
        public int ContactId { get; set; }

        public string ContactName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactValue { get; set; }


        public int ContactTypeId { get; set; }

        public DateTime ? Added { get; set; }

        public DateTime ? Deleted { get; set; }

        public DateTime ? Updated { get; set; }
    }
}
