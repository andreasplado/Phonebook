using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MinLength(3)]
        [MaxLength(128)]
        public string UserName { get; set; }

        [MinLength(3)]
        [MaxLength(128)]
        public string Password { get; set; }

        [MinLength(3)]
        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }


        [MinLength(2)]
        [MaxLength(128)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Deleted { get; set; }

        public DateTime? Updated { get; set; }


        public virtual List<Contact> Contacts { get; set; }
        public virtual List<UserInRole> UserInRoles { get; set; } 
        public virtual List<Log> Logs { get; set; }
        public virtual List<Favorite> Favorites { get; set; }
    }

}
