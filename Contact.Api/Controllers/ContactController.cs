using Contact.Infrastructure.CQRS.Commands.Request;
using Contact.Infrastructure.CQRS.Queries.Request;
using Contact.Manager.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactManager _contactManager;
        
        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }
       
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListContactQueryRequest requestModel)
        {
            var result = await _contactManager.GetAllContactAsync(requestModel);
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var requestModel = new GetContactQueryRequest
            {
                Id = id
            };

            var result = await _contactManager.GetContactAsync(requestModel);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("ContactAll")]
        public async Task<IActionResult> ListRelation([FromBody] ListContactQueryRequest request)
        {
            var result = await _contactManager.GetAllContactAsync(request);
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
       
        [HttpPost("NewContact")]
        public async Task<IActionResult> Post([FromBody] CreateContactCommandRequest requestModel)
        {
            var result = await _contactManager.CreateContactAsync(requestModel);
            if (result == null)
                return NotFound();

            return StatusCode(201, result);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContactCommandRequest requestModel)
        {
            var result = await _contactManager.UpdateContactAsync(requestModel);
            if (result == null)
                return NotFound();

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var requestModel = new DeleteContactCommandRequest
            {
                Id = id
            };

            var result = await _contactManager.DeleteContactAsync(requestModel);

            if (result == null)
                return NotFound();

            return Ok();
        }
    }
}
