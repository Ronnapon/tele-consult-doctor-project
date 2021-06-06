using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using tele_consult.Data.ViewModel;

namespace tele_consult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public ClientsService _clientsService;
        public ClientsController(ClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpPost]
        public IActionResult AddNewClient([FromBody] ClientVM client)
        {
            // Check Validate
            if (client.Client_Payment_MethodId == 3)
            {
                if (client.CreditCard_Number == "" 
                    || client.CreditCard_CCV_Number == "" 
                    || client.CreditCard_Name == "")
                {
                    return BadRequest("CreditCard Information is requited");
                }
            }
            else
            {
                if (client.CreditCard_Number != ""
                   || client.CreditCard_CCV_Number != ""
                   || client.CreditCard_Name != "")
                {
                    return BadRequest("CreditCard Information is not requited");
                }
            }
            _clientsService.AddNewClient(client);
            return Ok();
        }
    }
}
