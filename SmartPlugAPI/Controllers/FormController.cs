using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPlugAPI.Dto.Request;
using SmartPlugAPI.Dto.Response;
using SmartPlugAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPlugAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly FormService _service;

        public FormController(FormService service)
        {
            _service = service;
        }

        [HttpPost("send-message/{companyName}")]
        public async Task<ActionResult<object>> SendMessage([FromForm] FormRequestDto model, [FromRoute] string website)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Not found", "");
                return BadRequest(ModelState);
            }
            //Send the message through injected 
            var response = await _service.SendMessage(model, website);
            if (!response.Item1) return BadRequest(new BaseResponseDto { Success = response.Item1, Message = response.Item2 });
            return Ok(new BaseResponseDto { Success = response.Item1, Message = response.Item2 });
        }
    }
}
