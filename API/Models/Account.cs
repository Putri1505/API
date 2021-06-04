using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_Account")]
    public class Account
    {
        [Key]
        public int NIK { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual Profiling Profiling { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

    }


}
