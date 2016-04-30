using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string RoleName { get; set; }

        [MinLength(3)]
        [MaxLength(128)]
        public string RoleDescription { get; set; }


        public virtual List<UserInRole> UserInRoles { get; set; }

    }
}
