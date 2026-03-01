using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationOfSpecificPowerConsole.Common
{
    public class PowerCalculator
    {
        public static double CalculateSpecificPower(int currentFlat, int flatMin, int flatMax, double kilowattMin, double kilowattMax)
        {
            double kilowattDefference = kilowattMax - kilowattMin;
            int flatDefference = flatMax - flatMin;
            int currentFlatDef = currentFlat - flatMin;

            return kilowattMax - kilowattDefference / flatDefference * currentFlatDef;
        }

        public static double CalculateFullSpecificPower(int currentFlat, int flatMin, int flatMax, double kilowattMin, double kilowattMax)
        {
            return CalculateSpecificPower(currentFlat, flatMin, flatMax, kilowattMin, kilowattMax) * currentFlat;
        }

        public static double CalculateFullSpecificPower(int currentFlat, double specificPower)
        {
            return specificPower * currentFlat;
        }


        // Вычисление момента по длине ВЛ метров
        public static double CalculateMoment(double lenght, double fullSpecificPower)
        {
            return lenght * fullSpecificPower;
        }

        public static double CalculateMoment(double lenght, int currentFlat, int flatMin, int flatMax, double kilowattMin, double kilowattMax)
        {
            return lenght * CalculateFullSpecificPower(currentFlat, flatMin, flatMax, kilowattMin, kilowattMax);
        }

        // Вычисление % потерь по моменту и сечению мм.кв.
        public static double CalculateLossesPercent(double moment, double sectionMMkw)
        {
            return moment / sectionMMkw / 46;
        }

        public static double CalculateTok(double fullSpecificPower, double cosF = 0.98)
        {
            return fullSpecificPower / 0.38 / cosF / 1.73;
        }
    }
}
