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
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.BI.Options;
using Insomnia.Agreemod.Data.ViewModels.Input;

namespace Insomnia.Agreemod.API.Controllers
{
    [ApiController]
    [Route("agreemod/[Controller]")]
    public class NotionController : BaseController
    {
        private readonly ILogger<NotionController> _logger;
        private readonly IMapper _mapper;
        private readonly INotion _notion;
        private readonly IExcel _excel;
        private readonly FilesConfig _config;

        public NotionController(ILogger<NotionController> logger, IMapper mapper, INotion notion, IExcel excel)
        {
            _logger = logger;
            _mapper = mapper;
            _notion = notion;
            _excel = excel;
            _config = new FilesConfig();
        }

        [HttpGet("peoples")]
        public async Task<IActionResult> GetInfoForPeoples()
        {
            var result = await _notion.GetPeoples();
            if(result.Success)
                return Ok(result.Peoples);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("chat-users")]
        public async Task<IActionResult> GetChatUsers()
        {
            var result = await _notion.GetChatUsers();
            if (result.Success)
                return Ok(result.Users);

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
            var result = await _notion.GetTimetablesForLocations();
            if (result.Success)
                return Ok(result.Timetables);

            return BadRequest(result.ErrorMessage);
        }


        [HttpGet("schedules-a")]
        public async Task<IActionResult> GetInfoForSchedulesa()
        {
            var result = await _notion.GetTimetablesForLocations();
            if (result.Success)
                return Ok(result.Timetables);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("export-schedules")]
        public async Task<IActionResult> GetExportSchedules()
        {
            var result = await _notion.GetTimetablesForLocations();
            if (result.Success)
                return Ok(result.Timetables);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("export")]
        public async Task<IActionResult> GetExport()
        {
            return File(await _notion.ExportPeoples(), "application/octet-stream", _config.ZipFileName);
        }

        [HttpGet("export-locations")]
        public async Task<IActionResult> GetExportLocations()
        {
            return File(await _notion.ExportLocations(), "application/octet-stream", _config.ZipFileName);
        }

        [HttpPost("mark-arrivals")]
        public async Task<IActionResult> MarkArrival([FromBody] ArrivalUsers model)
        {
            return Ok(await _notion.MarkArrivals(model));
        }

        [HttpPost("mark-arrival")]
        public async Task<IActionResult> MarkArrival([FromBody] ArrivalUser model)
        {
            return Ok(await _notion.MarkArrival(model));
        }
    }
}
