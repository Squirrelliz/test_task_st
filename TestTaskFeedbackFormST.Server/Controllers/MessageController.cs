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

        [HttpGet("{id}", Name = nameof(GetMessage))] // именованный маршрут
        [ProducesResponseType(200, Type = typeof(DTOMessage))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMessage(int id)
        {
            DTOMessage? m = await serviceMessage.RetrieveAsync(id);
            if (m == null)
            {
                return NotFound(); // 404 – ресурс не найден
            }
            return Ok(m); // 200 – OK, с клиентом в теле
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(DTOMessage))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMessage([FromBody] DTOMessage m)
        {
            if (m == null)
            {
                return BadRequest(); // 400 – некорректный запрос
            }else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Message? addedMessage = await serviceMessage.CreateAsync(m);

            if (addedMessage == null)
            {
                return BadRequest("Repository failed to create customer.");
            }
            else
            {
                return CreatedAtRoute( // 201 – ресурс создан
                          routeName: nameof(GetMessage),
                          routeValues: new { id = addedMessage.Id },
                          value: m);
            }
        }
    }
 }

