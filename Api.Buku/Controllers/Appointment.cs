
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
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _bukuService;

        public AppointmentController(AppointmentService bukuService)
        {
            _bukuService = bukuService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> Get() =>
          await  _bukuService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAppointment")]
        public async  Task< ActionResult<Appointment>> Get(string id)
        {
            var users =await _bukuService.Get(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> Create(Appointment a)
        {
           await _bukuService.Create(a);

            return CreatedAtRoute("GetAppointment", new { id = a.Id.ToString() }, a);
        }


        //[HttpPost (Name = "AuthUser")]
        //public async Task<ActionResult<Users>> AuthUser(UserLogin Users)
        //{
        //   var result =  await _bukuService.AuthLogin(Users);

        //    return CreatedAtRoute("GetAuth", new { id = result.Id.ToString() }, Users);
        //}


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Appointment a)
        {
            var appt =await  _bukuService.Get(id);

            if (appt == null)
            {
                return NotFound();
            }

            _bukuService.Update(id, a);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var appt =await _bukuService.Get(id);

            if (appt == null)
            {
                return NotFound();
            }

            _bukuService.Remove(appt.Id);

            return NoContent();
        }
    }
}