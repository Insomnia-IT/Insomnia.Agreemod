using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Insomnia.Agreemod.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insomnia.Agreemod.BI.Interfaces;

namespace Insomnia.Agreemod.API.Controllers
{
    [ApiController]
    [Route("agreemod/[Controller]")]
    public class NotionController : BaseController
    {
        private readonly ILogger<NotionController> _logger;
        private readonly IMapper _mapper;
        private readonly INotion _notion;

        public NotionController(ILogger<NotionController> logger, IMapper mapper, INotion notion)
        {
            _logger = logger;
            _mapper = mapper;
            _notion = notion;
        }

        [HttpGet("peoples")]
        public async Task<IActionResult> GetInfoForPeoples()
        {
            var result = await _notion.GetPeoples();
            if(result.Success)
                return Ok(result.Peoples);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetInfoForLocations()
        {
            var result = await _notion.GetLocations();
            if (result.Success)
                return Ok(result.Locations);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("schedules")]
        public async Task<IActionResult> GetInfoForSchedules()
        {
            return Ok();
        }
    }
}
