using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationOfSpecificPowerConsole.Common
{
    public class ConsumerData
    {
        /* Каждому количеству квартир соответствует значение киловатт
         * для каждого вида потребителя
         * Например: кол-во потребителей: 5 (первый элемент в списке ConsumersCounts), 
         * тогда для природного газа - 4.5, для сжиженного газа - 6, для эл. плит - 10, а 
         * для садовых домиков - 4.
         * Массивы - параллельны
        */
        public static List<int> ConsumersCounts { get; set; } = new List<int> {
            5, 6, 9, 12, 15, 18, 24, 40, 60, 100, 200, 400, 600, 1000
        };

        // вид потребителей - природный газ
        public static List<double> NaturalGasKW { get; set; } = new List<double>
        {
            4.5, 2.8, 2.3, 2, 1.8, 1.65, 1.4, 1.2, 1.05, 0.85, 0.77, 0.71, 0.69, 0.67
        };

        // вид потребителя - сжиженный газ
        public static List<double> LiquefiedGas { get; set; } = new List<double>
        {
            6, 3.4, 2.9, 2.5, 2.2, 2, 1.8, 1.4, 1.3, 1.08, 1, 0.92, 0.84, 0.76
        };

        // вид потребителя - электрические плиты 8,5 кВт
        public static List<double> ElectricCookers { get; set; } = new List<double>
        {
            10, 5.1, 3.8, 3.2, 2.8, 2.6, 2.2, 1.95, 1.7, 1.5, 1.36, 1.27, 1.23, 1.19
        };

        //Вид потребителя - садовые домики
        public static List<double> GardenHouses { get; set; } = new List<double>
        {
            4, 2.3, 1.7, 1.4, 1.2, 1.1, 0.9, 0.76, 0.69, 0.61, 0.58, 0.54, 0.51, 0.46
        };


        /*
         * Формат возвращаемого значения - список с данными:
         * [текущее количество потребителей, мин. значение квартир, макс. значение квартир, мин. кВТ, макс. кВт]
        */
        public static List<double> GetDataList(int consCount, string consType)
        {
            List<double> ResultList = new List<double> { consCount };

            List<double> Selectedlist = new List<double>();

            if (consType == "электрические плиты")
            {
                Selectedlist = ElectricCookers;
            }
            else if (consType == "природный газ")
            {
                Selectedlist = NaturalGasKW;
            }
            else if (consType == "сжиженный газ")
            {
                Selectedlist = LiquefiedGas;
            }
            else if (consType == "садовые домики")
            {
                Selectedlist = GardenHouses;
            }
            
            

            for (int i = 0; i < ConsumersCounts.Count; i++)
            {
                if (ConsumersCounts[i] >= consCount)
                {
                    if (i != 0)
                    {
                        ResultList.Add(ConsumersCounts[i - 1]); // добавил мин. значение квартир
                        ResultList.Add(ConsumersCounts[i]); // добавил макс. значение квартир
                        ResultList.Add(Selectedlist[i]); // добавил мин. значение кВт
                        ResultList.Add(Selectedlist[i - 1]); // добавил макс. значение кВт
                    }
                    else
                    {
                        ResultList.Add(1); // добавил мин. значение квартир
                        ResultList.Add(ConsumersCounts[i]); // добавил макс. значение квартир
                        ResultList.Add(Selectedlist[i]); // добавил мин. значение кВт
                        ResultList.Add(Selectedlist[i]); // добавил макс. значение кВт
                    }
                }
            }

            return ResultList;
        }
    }
}
