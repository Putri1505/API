using API.Base;
using API.Models;
using API.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class EducationController : BaseController<Education, EducationRepository, int>
    {
        public EducationController(EducationRepository education) : base(education)
        {

        }
    
    }
}
