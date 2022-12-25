using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.DTOs;
using System.Net;

namespace NLayerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };


        }
    }
}
