using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Service;

namespace VR2_Klientrakendus.Models
{
    public class User
    {
        public int  UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public DateTime? Added { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? Updated { get; set; }                                                                                                                                                                                
    }
}
