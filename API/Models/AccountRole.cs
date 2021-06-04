using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_AccountRole")]
    public class AccountRole
    {
        public int NIK { get; set; }
        public int Roleid { get; set; }
        public virtual Role Role { get; set; }
        public virtual Account Account { get; set;}
    }
}
