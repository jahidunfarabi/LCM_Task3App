using Microsoft.AspNetCore.Mvc;

namespace LCM_Task3App.Controllers
{
    [ApiController]
    public class LcmController : ControllerBase
    {
        [HttpGet("{email}")]
        public IActionResult GetLcm([FromRoute] string email, [FromQuery] long x, [FromQuery] long y)
        {
            if (x <= 0 || y <= 0)
            {
                return BadRequest(new { error = "Parameters x and y must be positive integers." });
            }

            long lcmValue = CalculateLCM(x, y);
            return Ok(lcmValue);
        }

        private static long CalculateGCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static long CalculateLCM(long a, long b)
        {
            return (a / CalculateGCD(a, b)) * b;
        }
    }
}