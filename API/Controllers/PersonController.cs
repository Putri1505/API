using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
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

        public PersonController(PersonRepository person) : base(person)
        {
            this.personRepository = person;
        }
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = personRepository.Register(registerVM);
                    if (data > 0)
                    {
                        return Ok("Register Berhasil");
                    }
                    else
                    {
                        return StatusCode(500, new { status = "Internal server error..." });
                    }
                }
                catch (DbUpdateException)
                {
                    return BadRequest($"NIK {registerVM.NIK} Sudah ada");
                }
            }
            else
            {
                return BadRequest("Data input tidak valid");
            }
        }
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
            if (ModelState.IsValid)
            {
                var data = personRepository.LoginVM(loginVM);
                if (data == 1)
                {
                    return Ok("Login Berhasil");
                }
                return BadRequest("Login Gagal");
            }
            return BadRequest("Login Gagal");
        }
    }

}
