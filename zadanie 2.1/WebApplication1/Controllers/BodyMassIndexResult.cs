using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyMassIndexController : ControllerBase
    {
        [HttpGet]
        public ActionResult<BodyMassIndexResult> Get(double height, double weight)
        {
            if (height <= 0 || height > 3 || weight <= 0)
            {
                return BadRequest("Invalid height or weight.");
            }

            var bmi = weight / (height * height);
            var description = GetDescription(bmi);

            var result = new BodyMassIndexResult
            {
                Value = bmi,
                Description = description
            };

            return Ok(result);
        }

        private static string GetDescription(double bmi)
        {
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi < 25)
            {
                return "Normal weight";
            }
            else if (bmi < 30)
            {
                return "Overweight";
            }
            else
            {
                return "Obese";
            }
        }
    }

}