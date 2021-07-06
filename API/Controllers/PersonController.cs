using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = personRepository.LoginVM(loginVM);
            if (login == 404)
            {
                return BadRequest("Email tidak ditemukan, Silahkan gunakan email lain");
            }
            else if (login == 401)
            {
                return BadRequest("Password salah");
            }
            else if (login == 1)
            {
                return Ok(new JWTokenVM
                {
                    Token = personRepository.GenerateToken(loginVM),
                    Messages = "Login Success"

                });
            }
            else
            {
                return BadRequest("Gagal Login");
            }

        }
        //[Authorize(Roles = "Admin, Karyawan")]
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
        //[Authorize(Roles = "Admin, Karyawan")]
        [HttpGet("GetProfileById/{nik}")]
        [EnableCors("AllowOrigin")]
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
        //[Authorize(Roles = "Admin, Karyawan")]
        [EnableCors("AllowOrigin")]
        [HttpPost("DeleteProfileById/{nik}")]
        public ActionResult DeleteProfileById(int nik)
        {
            var delete = personRepository.DeleteProfileById(nik);
            if (delete != 0)
            {
                return Ok("data terhapus");
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }
        [EnableCors("AllowOrigin")]
        [HttpPut("UpdateProfile")]
        public ActionResult UpdateProfile(Person person)
        {
            var update = personRepository.UpdateProfile(person);
            if (update != 0)
            {
                return Ok("data terupdate");
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }
    }

}
