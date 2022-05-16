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

namespace Insomnia.Agreemod.API.Controllers
{
    [ApiController]
    [Route("agreemod/[Controller]")]
    public class TicketscloudController : BaseController
    {
        private readonly ILogger<TicketscloudController> _logger;
        private readonly IMapper _mapper;

        public TicketscloudController(ILogger<TicketscloudController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
    }
}
