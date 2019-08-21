using Services.Core;
using Services.DTO;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web.App.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {

        private readonly IClientService _ClientService;

        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddClient([FromBody] ClientDTO client)
        {
            return Ok(await _ClientService.AddClient(client));
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetClients()
        {
            return Ok(await _ClientService.GetClients());
        }
        
    }
}
