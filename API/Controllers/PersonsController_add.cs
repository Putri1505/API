using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonsController_add : ControllerBase
    {
        private readonly PersonRepository_add personRepository;
        public PersonsController_add(PersonRepository_add personRepository)
        {
            this.personRepository = personRepository;

        }
        [HttpPost]
        public ActionResult Post(Person person)
        {
            var post = personRepository.Insert(person);
            if (post != null)
            {
                return Ok("Data Berhasil");
            }
            else
            {
                return BadRequest("Data Tidak Berhasil");
            }
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<Person> get = personRepository.Get().ToList();
            if (get.Count > 0)
            {
                return Ok("Data Behasil");
            }
            return BadRequest("Data Tidak Tersedia");
            
        }
        [HttpGet("{nik}")]
        public ActionResult Get(int nik)
        {
            var Get = personRepository.Get(nik);
            if (Get != null)
            {
                return Ok(Get);
            }
            return NotFound($"Data NIK {nik} Tidak Tersedia");
        }
        [HttpDelete("{nik}")]
        public ActionResult Delete(int nik)
        {
            var get = personRepository.Delete(nik);
            if(get > 0)
            {
                return Ok("Berhasil Terhapus");
            }
            return BadRequest($"Data NIK {nik} Tidak Tersedia");
        }
        [HttpPut]
        public ActionResult Update(Person person)
        {
            if (person.NIK == 0)
            {
                return BadRequest("data gagal diupdate nik harus di input");
            }
            var get = personRepository.Update(person, person.NIK);
            if(get > 0)
            {
                return Ok("Update Berhasil");
            }
            else
            {
                return BadRequest("Data Gagal diupdate");
            }
        }
       
    }
}
