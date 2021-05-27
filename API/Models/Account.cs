using Microsoft.EntityFrameworkCore;
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
        public virtual Person Person { get; set; }
        public virtual Profiling Profiling { get; set; }
    }
   
    
}
