using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
        [Authorize]
        public IActionResult GetAllDoctors(string search, string specialization, int page)
        {
            // var currentUser = HttpContext.User;
            // int spendingTimeWithCompany = 0;
            // currentUser.HasClaim(c => c.Type == "DateOfJoing"))
            //{
               // DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "DateOfJoing").Value);
               // spendingTimeWithCompany = DateTime.Today.Year - date.Year;
            //}

            var doctors = _doctorsService.GetAllDoctors(search, specialization, page);
            return Ok(doctors);
        }
    }
}
