using Microsoft.AspNetCore.Mvc;
using tele_consult.Data.Models.Services;
using tele_consult.Data.ViewModel;

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

        [HttpPost]
        public IActionResult AddDoctor([FromBody] DoctorVM doctor)
        {
            _doctorsService.AddDoctor(doctor);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllDoctors(string search, string specialization, int page)
        { 
            var doctors = _doctorsService.GetAllDoctors(search, specialization, page);
            return Ok(doctors);
        }

        [HttpGet("{Id}")]
        public IActionResult GetDoctor(int Id)
        {
            var doctor = _doctorsService.GetDoctor(Id);
            return Ok(doctor);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateDoctor([FromBody] DoctorVM doctor,int Id)
        {
            _doctorsService.UpdateDoctor(doctor,Id);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(int Id)
        {
            _doctorsService.GetDoctor(Id);
            return Ok();
        }
    }
}
