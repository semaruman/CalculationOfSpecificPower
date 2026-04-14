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
            KoefComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ConsumerTypesComboBox.Items.Add("природный газ");
            ConsumerTypesComboBox.Items.Add("сжиженный газ");
            ConsumerTypesComboBox.Items.Add("электрические плиты");
            ConsumerTypesComboBox.Items.Add("садовые домики");

            KoefComboBox.Items.Add("Аллюминий");
            KoefComboBox.Items.Add("Медь");
            KoefComboBox.SelectedIndex = 0;
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

            specificPowertextBox.Text = $"{Math.Round(specPower, 3)}";
            specificPowerFullTextBox.Text = $"{Math.Round(fullspecPower, 3)}";
            powerTextBox.Text = $"{Math.Round(fullspecPower, 3)}".Replace('.', ',');
            tokTextBox.Text = $"{Math.Round(tok, 3)}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double power = -1;
            try
            {
                power = Convert.ToDouble(powerTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Мощность не расчитана. Вещественные числа отделяются запятой");
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

            var moment = PowerCalculator.CalculateMoment(length, power);
            momentTextBox.Text = $"{Math.Round(moment, 3)}";
        }

        private void tokTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double power = -1;
            try
            {
                power = Convert.ToDouble(powerTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Мощность не расчитана. Вещественные числа отделяются запятой");
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

            double S = -1;
            try
            {
                S = Convert.ToDouble(sectionTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Сечение должно быть числом; Вещественные числа отделяются запятой", "Не верный формат входных данных");
                return;
            }

            double C = -1;
            if (KoefComboBox.Text == "Аллюминий")
            {
                C = 44;
            }
            else if (KoefComboBox.Text == "Медь")
            {
                C = 72;
            }
            else
            {
                MessageBox.Show("Не выбран коэффициент");
            }

            double losses = PowerCalculator.CalculateLosses(power, length, C, S);

            lossesTextBox.Text = Math.Round(losses, 2).ToString();
        }
    }
}

