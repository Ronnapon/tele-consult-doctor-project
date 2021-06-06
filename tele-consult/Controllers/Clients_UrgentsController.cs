using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models.Services;
using tele_consult.Data.ViewModel;

namespace tele_consult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Clients_UrgentsController : ControllerBase
    {
        public Clients_UrgentsService _clients_UrgentsService;
        public Clients_UrgentsController(Clients_UrgentsService clients_UrgentsService)
        {
            _clients_UrgentsService = clients_UrgentsService;
        }

        [HttpPost]
        public IActionResult AddNewClient_Urgent([FromBody] Client_UrgentVM client_urgent)
        {
            _clients_UrgentsService.AddNewClient_Urgent(client_urgent);
            return Ok();
        }
    }
}
