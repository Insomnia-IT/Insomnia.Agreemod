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

        public NotionController(ILogger<NotionController> logger, IMapper mapper, INotion notion, IExcel excel)
        {
            _logger = logger;
            _mapper = mapper;
            _notion = notion;
            _excel = excel;
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

        [HttpGet("export")]
        public async Task<IActionResult> GetExport()
        {
            return File(_excel.ExcelFileGenerate<Badge>(new List<Badge>()
                {
                    new Badge()
                    {
                        Name = "ИМЯ",
                        Type = "ТИП ПЕРВЫЙ"
                    },
                    new Badge()
                    {
                        Name = "Иван Иваныч",
                        Type = "Человечек",
                    },
                    new Badge()
                    {
                        Name = "ВАААААААААААААААААА",
                        Type = "Типа типа топ"
                    },
                    new Badge()
                    {
                        Name = "1",
                        Type = null,
                    },
                    new Badge()
                    {
                        Name = null,
                        Type = "2",
                    }
                }), "application/octet-stream", "MyWorkbook.xlsx");
        }
    }
}
