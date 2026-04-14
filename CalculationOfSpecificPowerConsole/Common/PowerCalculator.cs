using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CalculationOfSpecificPowerConsole.Common
{
    public static class PowerCalculator
    {
        private static readonly ILogger _logger = LoggingFactory.CreateLogger("PowerCalculator");
        public static double CalculateSpecificPower(int currentFlat, int flatMin, int flatMax, double kilowattMin, double kilowattMax)
        {
            double kilowattDefference = kilowattMax - kilowattMin;
            int flatDefference = flatMax - flatMin;
            int currentFlatDef = currentFlat - flatMin;
            double specificPower = kilowattMax - kilowattDefference / flatDefference * currentFlatDef;

            _logger.LogInformation("Удельная мощность: {spec}", specificPower);

            return specificPower;
        }

        public static double CalculateFullSpecificPower(int currentFlat, int flatMin, int flatMax, double kilowattMin, double kilowattMax)
        {
            double fulSpecificPower = CalculateSpecificPower(currentFlat, flatMin, flatMax, kilowattMin, kilowattMax) * currentFlat;

            _logger.LogInformation("Полная мощность: {spec}", fulSpecificPower);

            return fulSpecificPower;
        }

        public static double CalculateFullSpecificPower(int currentFlat, double specificPower)
        {
            double fulSpecificPower = specificPower * currentFlat;

            _logger.LogInformation("Полная мощность: {spec}", fulSpecificPower);

            return fulSpecificPower;
        }


        // Вычисление момента по длине ВЛ метров
        public static double CalculateMoment(double lenght, double fullSpecificPower)
        {
            double moment = lenght * fullSpecificPower;

            _logger.LogInformation("Момент: {moment}", moment);

            return moment;
        }

        public static double CalculateMoment(double lenght, int currentFlat, int flatMin, int flatMax, double kilowattMin, double kilowattMax)
        {
            double moment = lenght * CalculateFullSpecificPower(currentFlat, flatMin, flatMax, kilowattMin, kilowattMax);

            _logger.LogInformation("Момент: {moment}", moment);

            return moment;
        }

        // Вычисление % потерь по моменту и сечению мм.кв.
        public static double CalculateLossesPercent(double moment, double sectionMMkw)
        {

            double lossesPercent = moment / sectionMMkw / 46;

            _logger.LogInformation("Процент потерь: {lossesPercent}", lossesPercent);

            return lossesPercent;
        }

        public static double CalculateTok(double fullSpecificPower, double cosF = 0.98)
        {
            double tok = fullSpecificPower / 0.38 / cosF / Math.Sqrt(3);

            _logger.LogInformation("Ток: {tok}", tok);

            return tok;
        }

        //расчёт потерь. Принимает мощность, длину в метрах, коэффициент С, площадь сечения S
        public static double CalculateLosses(double power, double length, double C, double S)
        {
            double losses = (power * length) / (C * S);
            _logger.LogInformation("Потери: {losses}", losses);
            return losses;
        }
    }
}
