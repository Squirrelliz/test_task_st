using Microsoft.AspNetCore.Mvc;
using TestTaskFeedbackFormST.Server.Models;
using TestTaskFeedbackFormST.Server.Services;

namespace TestTaskFeedbackFormST.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ImessageService serviceMessage;
        public MessageController(ImessageService serviceMessage)
        {
           this.serviceMessage = serviceMessage;
        }

        [HttpGet("{id}")] 
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DTOMessage>> GetMessage(int id)
        {
            DTOMessage? m = await serviceMessage.RetrieveAsync(id);
            if (m is null)
            {
                return NotFound(); 
            }
            return Ok(m); 
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<DTOMessage>> CreateMessage( DTOMessage m)
        {
            if (m is null)
            {
                return BadRequest(); 
            }else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            m.phone = '8' + m.phone;

            Message? addedMessage = await serviceMessage.CreateAsync(m);

            if (addedMessage == null)
            {
                return BadRequest("Repository failed to create customer.");
            }
            else
            {
                return CreatedAtAction( 
                           nameof(GetMessage),
                          new { id = addedMessage.Id },
                           m);
            }
        }
    }
 }

