﻿using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UniversityRepository : GeneralRepository<MyContext, Account, int>
    {
        public UniversityRepository(MyContext myContext) : base(myContext)
        {

        }
    
    }
}