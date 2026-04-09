using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculationOfSpecificPowerConsole.Common;

namespace CalculationOfSpecificPowerConsole.Tests.Common
{
    public class PowerCalculatorTest
    {
        [Theory]
        [InlineData(23, 18, 24, 1.4, 1.65)]
        public void CalculateSpecificPower_ReturnsCorrectNumber(
            int currentFlat, 
            int flatMin, 
            int flatMax, 
            double kilowattMin, 
            double kilowattMax)
        {
            double kilowattDefference = kilowattMax - kilowattMin;
            int flatDefference = flatMax - flatMin;
            int currentFlatDef = currentFlat - flatMin;

            double correctSpecificPower = kilowattMax - kilowattDefference / flatDefference * currentFlatDef;
            double calculatorSpecificPower = PowerCalculator.CalculateSpecificPower(currentFlat, flatMin, flatMax, kilowattMin, kilowattMax);

            Assert.Equal(correctSpecificPower, calculatorSpecificPower);
        }
    }
}
