using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculationOfSpecificPowerConsole.Common;

namespace CalculationOfSpecificPower.Tests.Common
{
    public class ConsumerDataTest
    {
        [Theory]
        [InlineData(16, "электрические плиты", new double[] { 16.0, 15.0, 18.0, 2.6, 2.8 })]
        [InlineData(0, "электрические плиты", new double[] { 0, 1.0, 5.0, 10.0, 10.0 })]
        public void GetDataList_ReturnsCorrectData(int consCount, string consType, double[] res)
        {
            var dataList = ConsumerData.GetDataList(consCount, consType);

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(res[i], dataList[i]);
            }
        }
    }
}
