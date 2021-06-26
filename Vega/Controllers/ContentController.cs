using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vega.DTO;
using Vega.Entities;
using Vega.Interfaces;

namespace Vega.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentController: ControllerBase
    {
        private IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost("/most-winners")]
        public async Task<IActionResult> MostWinners([FromBody] int pageSize, int pageNumber)
        {
            List<MostWinnersDTO> winnerData = await _contentService.GetMostWinners(pageSize, pageNumber);
            string response = JsonConvert.SerializeObject(winnerData);
            return Ok(response);
        }
    }
}