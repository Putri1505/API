using API.Base;
using API.Models;
using API.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProfilingController : BaseController<Profiling, ProfilingRepository, int>
    {
        public ProfilingController(ProfilingRepository profiling) : base(profiling)
        {

        }
    }
}
