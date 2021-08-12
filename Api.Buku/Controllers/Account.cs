
using Api.Buku.Models;
using Api.Buku.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Buku.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly BukuService _bukuService;

        public AccountController(BukuService bukuService)
        {
            _bukuService = bukuService;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Users>>> Get() =>
        //  await  _bukuService.Get();

        //[HttpGet("{id:length(24)}", Name = "GetUsers")]
        //public async  Task< ActionResult<Users>> Get(string id)
        //{
        //    var users =await _bukuService.Get(id);

        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return users;
        //}

        //[HttpPost]
        //public async Task<ActionResult<Users>> Create(Users Users)
        //{
        //   await _bukuService.Create(Users);

        //    return CreatedAtRoute("GetUsers", new { id = Users.Id.ToString() }, Users);
        //}


        [HttpPost(Name = "AuthLogin")]
        public async Task<ActionResult<Users>> AuthUser(UserLogin Users)
        {
            var result = await _bukuService.AuthLogin(Users);
            if(result == null)
                return NotFound();
            else

            return result;
        }


        //[HttpPut("{id:length(24)}")]
        //public async Task<IActionResult> Update(string id, Users Users)
        //{
        //    var users =await  _bukuService.Get(id);

        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    _bukuService.Update(id, Users);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var users =await _bukuService.Get(id);

        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    _bukuService.Remove(users.Id);

        //    return NoContent();
        //}
    }
}