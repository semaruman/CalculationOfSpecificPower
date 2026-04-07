using CalculationOfSpecificPowerConsole.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculationOfSpecificPowerWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("specific-power")]
        public IActionResult GetSpecificPower(int count, string type)
        {
            var dataList = ConsumerData.GetDataList(count, type);
            if (dataList == null)
            {
                return BadRequest("Неверный тип потребителя");
            }

            double specPower = PowerCalculator.CalculateSpecificPower((int)dataList[0], (int)dataList[1], (int)dataList[2], dataList[3], dataList[4]);
            
            return Ok(new
            {
                SpecificPower = specPower,
            });
        }

        [HttpGet("rated-power")]
        public IActionResult GetRatedPower(int count, string type)
        {
            var dataList = ConsumerData.GetDataList(count, type);
            if (dataList == null)
            {
                return BadRequest("Неверный тип потребителя");
            }

            double specPower = PowerCalculator.CalculateSpecificPower((int)dataList[0], (int)dataList[1], (int)dataList[2], dataList[3], dataList[4]);
            double fullspecPower = PowerCalculator.CalculateFullSpecificPower(count, specPower);

            return Ok(new
            {
                FellSpecificPower = fullspecPower,
            });
        }


        [HttpGet("electric-current")]
        public IActionResult GetElectricCurrent(int count, string type, double cosF = 0.98)
        {
            var dataList = ConsumerData.GetDataList(count, type);
            if (dataList == null)
            {
                return BadRequest("Неверный тип потребителя");
            }

            double specPower = PowerCalculator.CalculateSpecificPower((int)dataList[0], (int)dataList[1], (int)dataList[2], dataList[3], dataList[4]);
            double fullspecPower = PowerCalculator.CalculateFullSpecificPower(count, specPower);

            double tok = PowerCalculator.CalculateTok(fullspecPower, cosF);

            return Ok(new { 
                ElectricCurrent = tok,
            });
        }

        [HttpGet("moment")]
        public IActionResult GetMoment(int count, string type, double length)
        {
            var dataList = ConsumerData.GetDataList(count, type);
            if (dataList == null)
            {
                return BadRequest("Неверный тип потребителя");
            }

            double specPower = PowerCalculator.CalculateSpecificPower((int)dataList[0], (int)dataList[1], (int)dataList[2], dataList[3], dataList[4]);
            double fullspecPower = PowerCalculator.CalculateFullSpecificPower(count, specPower);
            double moment = PowerCalculator.CalculateMoment(length, fullspecPower);

            return Ok(new
            {
                Moment = moment,
            });
        }
    }
}
