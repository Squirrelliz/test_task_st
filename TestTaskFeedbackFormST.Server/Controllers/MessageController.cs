﻿using Microsoft.AspNetCore.Mvc;
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
                return NotFound("FUCKING BUG"); // 404 – ресурс не найден
            }
            return Ok(m); // 200 – OK, с клиентом в теле
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<DTOMessage>> CreateMessage( DTOMessage m)
        {
            if (m is null)
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
                return CreatedAtAction( // 201 – ресурс создан
                           nameof(GetMessage),
                          new { id = addedMessage.Id },
                           m);
            }
        }
    }
 }

