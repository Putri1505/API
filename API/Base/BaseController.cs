using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase 
        where Entity : class where Repository : IRepository<Entity, Key>
    {
        Repository repo;
        public BaseController(Repository repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            var post = repo.Insert(entity);
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
        public ActionResult<Entity> Get()
        {
            var get = repo.Get();
            if (get.ToList().Count > 0)
            {
                return Ok(get);
            }
            else
            {
                return Ok("No Record");
            }
        }
        [HttpGet("{key}")]
        public ActionResult<Entity> Get(Key key)
        {
            var get = repo.Get(key);
            if (get != null)
            {
                return Ok(get);
            }
            return NotFound($"Data NIK {key} Tidak Tersedia");
        }
        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            try
            {
                var get = repo.Delete(key);
                if (get > 0)
                {
                    return Ok("Berhasil Terhapus");
                }
            }
            catch (ArgumentNullException e)
            {
                return NotFound($"Data NIK {key} Tidak Tersedia");
            }
            return BadRequest();
        }
        [HttpPut]
        public ActionResult Update(Entity entity)
        {
            try
            {
                var result = repo.Update(entity);
                return Ok(new { Status = "OK"});
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound($"Data Gagal DiUpdate");
            }
        }

    }
}
