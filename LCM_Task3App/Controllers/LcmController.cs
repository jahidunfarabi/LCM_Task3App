using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Task3LCMApp.Controllers
{
    [ApiController]
    [Route("jahidunmuntaka25_gmail_com")]
    public class LcmController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLcm([FromQuery] string? x, [FromQuery] string? y)
        {
            if (string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y))
            {
                return Content("NaN", "text/plain");
            }

            if (!BigInteger.TryParse(x, out BigInteger numberX) || !BigInteger.TryParse(y, out BigInteger numberY))
            {
                return Content("NaN", "text/plain");
            }

            if (numberX <= 0 || numberY <= 0)
            {
                return Content("NaN", "text/plain");
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(numberX, numberY);
            BigInteger lcm = (numberX / gcd) * numberY;

            return Content(lcm.ToString(), "text/plain");
        }
    }
}