using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<Person, PersonRepository, int>
    {
        private readonly PersonRepository personRepository;
        //private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public PersonController(PersonRepository person) : base(person)
        {
            this.personRepository = person;
            //this.jWTAuthenticationManager = jWTAuthenticationManager;
        }
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var data = personRepository.Register(registerVM);
            if (data > 0)
            {
                return Ok("Register Berhasil");
            }
            else
            {
                return BadRequest("register tidak berhasil");
            }
        }
        [Authorize]
        [HttpGet("GetAllProfile")]
        public ActionResult GetAllProfile()
        {
            var get = personRepository.GetAllProfile();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }
        [Authorize]
        [HttpGet("GetProfileById/{nik}")]
        public ActionResult GetProfileById(int nik)
        {
            var get = personRepository.GetProfileById(nik);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
                var data = personRepository.LoginVM(loginVM);
                if (data > 0 )
                {
                    return Ok($"Login Berhasil \n Token : {personRepository.GenerateToken(loginVM)}");
                }
                return BadRequest("Email atau Password tidak sesuai");
            
        }
    }

}
