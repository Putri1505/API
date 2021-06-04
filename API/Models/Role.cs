using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_Role")]
    public class Role
    {
        [Key]
        public int Roleid { get; set; }
        public string NameRole { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

    }
}
