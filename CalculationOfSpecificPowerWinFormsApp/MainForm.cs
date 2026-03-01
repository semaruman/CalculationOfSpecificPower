using CalculationOfSpecificPowerConsole.Common;


namespace CalculationOfSpecificPowerWinFormsApp
{
    public partial class MainForm : Form
    {
        double fullspecPower = -1;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConsumerTypesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ConsumerTypesComboBox.Items.Add("природный газ");
            ConsumerTypesComboBox.Items.Add("сжиженный газ");
            ConsumerTypesComboBox.Items.Add("электрические плиты");
            ConsumerTypesComboBox.Items.Add("садовые домики");
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int consCount;
            try
            {
                consCount = Convert.ToInt32(ConsumersCountTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Количество потребителей должно быть числом", "Не верный формат входных данных");
                return;
            }

            string consType = ConsumerTypesComboBox.Text;
            if (consType == null || consType == string.Empty)
            {
                MessageBox.Show("Вы не выбрали потребителя");
                return;
            }

            var dataList = ConsumerData.GetDataList(consCount, consType);

            var specPower = PowerCalculator.CalculateSpecificPower((int)dataList[0], (int)dataList[1], (int)dataList[2], dataList[3], dataList[4]);
            fullspecPower = PowerCalculator.CalculateFullSpecificPower(consCount, specPower);

            double cosF;

            try
            {
                cosF = Convert.ToDouble(cosFTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Косинус фи должен быть числом; вещественнные числа отделяются запятой", "Не верный формат входных данных");
                return;
            }

            var tok = PowerCalculator.CalculateTok(fullspecPower, cosF);

            specificPowertextBox.Text = $"{Math.Round(specPower, 2)}";
            specificPowerFullTextBox.Text = $"{Math.Round(fullspecPower, 2)}";
            tokTextBox.Text = $"{Math.Round(tok, 2)}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fullspecPower == -1)
            {
                MessageBox.Show("Мощность не расчитана");
                return;
            }

            double length = -1;

            try
            {
                length = Convert.ToDouble(LEPlengthTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Длина ЛЭП должна быть числом", "Не верный формат входных данных");
                return;
            }

            var moment = PowerCalculator.CalculateMoment(length, fullspecPower);
            momentTextBox.Text = $"{Math.Round(moment, 2)}";
        }
    }
}
