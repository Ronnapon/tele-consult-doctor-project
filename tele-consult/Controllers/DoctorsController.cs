using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models.Services;

namespace tele_consult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        public DoctorsService _doctorsService;
        public DoctorsController(DoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [HttpGet]
        public IActionResult GetAllDoctors(string search, string specialization)
        {
            var doctors = _doctorsService.GetAllDoctors(search, specialization);
            return Ok(doctors);
        }
    }
}
