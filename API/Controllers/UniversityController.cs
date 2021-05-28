using API.Base;
using API.Models;
using API.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UniversityController : BaseController<University, UniversityRepository, int>
    {
        public UniversityController(UniversityRepository university) : base(university)
        {

        }
    }
}
