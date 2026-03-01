using CalculationOfSpecificPowerConsole.Common;

public class Program
{
    public static void Main()
    {
        

        Console.WriteLine("Введите количество потребителей:");

        int consCount = Convert.ToInt32(Console.ReadLine());

        var dataList = ConsumerData.GetDataList(consCount);

        var specPower = PowerCalculator.CalculateSpecificPower((int)dataList[0], (int)dataList[1], (int)dataList[2], dataList[3], dataList[4]);
        var fullspecPower = PowerCalculator.CalculateFullSpecificPower(consCount, specPower);
        Console.WriteLine($"На одну квартиру: {specPower}");
        Console.WriteLine($"На все квартиры: {fullspecPower}");
    }
}