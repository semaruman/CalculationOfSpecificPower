namespace CalculationOfSpecificPowerWinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            ConsumersCountTextBox = new TextBox();
            ConsumerTypesComboBox = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            CalculateButton = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cosFTextBox = new TextBox();
            specificPowertextBox = new TextBox();
            specificPowerFullTextBox = new TextBox();
            tokTextBox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            label10 = new Label();
            momentTextBox = new TextBox();
            label11 = new Label();
            LEPlengthTextBox = new TextBox();
            label12 = new Label();
            label13 = new Label();
            lossesTextBox = new TextBox();
            label14 = new Label();
            powerTextBox = new TextBox();
            sectionTextBox = new TextBox();
            label15 = new Label();
            KoefComboBox = new ComboBox();
            label16 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 78);
            label1.Name = "label1";
            label1.Size = new Size(155, 15);
            label1.TabIndex = 0;
            label1.Text = "Количество потребителей:";
            // 
            // ConsumersCountTextBox
            // 
            ConsumersCountTextBox.Location = new Point(30, 96);
            ConsumersCountTextBox.Name = "ConsumersCountTextBox";
            ConsumersCountTextBox.Size = new Size(100, 23);
            ConsumersCountTextBox.TabIndex = 1;
            // 
            // ConsumerTypesComboBox
            // 
            ConsumerTypesComboBox.FormattingEnabled = true;
            ConsumerTypesComboBox.Location = new Point(30, 167);
            ConsumerTypesComboBox.Name = "ConsumerTypesComboBox";
            ConsumerTypesComboBox.Size = new Size(121, 23);
            ConsumerTypesComboBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 149);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 3;
            label2.Text = "Тип потребителя:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.Location = new Point(240, 307);
            label3.Name = "label3";
            label3.Size = new Size(105, 23);
            label3.TabIndex = 4;
            label3.Text = "Результат";
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(172, 250);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(114, 45);
            CalculateButton.TabIndex = 5;
            CalculateButton.Text = "Рассчитать мощность";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 350);
            label4.Name = "label4";
            label4.Size = new Size(132, 15);
            label4.TabIndex = 6;
            label4.Text = "Итого кВт на 1 кв, Pуд.:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 374);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 7;
            label5.Text = "Итого кВт, Рр:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(100, 400);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 8;
            label6.Text = "Ток, Iр:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 220);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 9;
            label7.Text = "Cos ф";
            // 
            // cosFTextBox
            // 
            cosFTextBox.Location = new Point(45, 238);
            cosFTextBox.Name = "cosFTextBox";
            cosFTextBox.Size = new Size(74, 23);
            cosFTextBox.TabIndex = 10;
            cosFTextBox.Text = "0,98";
            // 
            // specificPowertextBox
            // 
            specificPowertextBox.Location = new Point(161, 342);
            specificPowertextBox.Name = "specificPowertextBox";
            specificPowertextBox.Size = new Size(100, 23);
            specificPowertextBox.TabIndex = 11;
            // 
            // specificPowerFullTextBox
            // 
            specificPowerFullTextBox.Location = new Point(161, 371);
            specificPowerFullTextBox.Name = "specificPowerFullTextBox";
            specificPowerFullTextBox.Size = new Size(100, 23);
            specificPowerFullTextBox.TabIndex = 12;
            // 
            // tokTextBox
            // 
            tokTextBox.Location = new Point(161, 400);
            tokTextBox.Name = "tokTextBox";
            tokTextBox.Size = new Size(100, 23);
            tokTextBox.TabIndex = 13;
            tokTextBox.TextChanged += tokTextBox_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(442, 427);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 14;
            label8.Text = "Румянцев С.Д.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(442, 442);
            label9.Name = "label9";
            label9.Size = new Size(132, 15);
            label9.TabIndex = 15;
            label9.Text = "semaruman@yandex.ru";
            // 
            // button1
            // 
            button1.Location = new Point(309, 250);
            button1.Name = "button1";
            button1.Size = new Size(114, 45);
            button1.TabIndex = 16;
            button1.Text = "Рассчитать момент";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(319, 350);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 17;
            label10.Text = "Момент:";
            // 
            // momentTextBox
            // 
            momentTextBox.Location = new Point(299, 371);
            momentTextBox.Name = "momentTextBox";
            momentTextBox.Size = new Size(100, 23);
            momentTextBox.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(309, 182);
            label11.Name = "label11";
            label11.Size = new Size(112, 15);
            label11.TabIndex = 19;
            label11.Text = "Длина ЛЭП метров";
            // 
            // LEPlengthTextBox
            // 
            LEPlengthTextBox.Location = new Point(311, 200);
            LEPlengthTextBox.Name = "LEPlengthTextBox";
            LEPlengthTextBox.Size = new Size(100, 23);
            LEPlengthTextBox.TabIndex = 20;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label12.Location = new Point(161, 9);
            label12.Name = "label12";
            label12.Size = new Size(262, 26);
            label12.TabIndex = 21;
            label12.Text = "Расчёт удельной мощности";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(477, 350);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 22;
            label13.Text = "Потери:";
            // 
            // lossesTextBox
            // 
            lossesTextBox.Location = new Point(454, 371);
            lossesTextBox.Name = "lossesTextBox";
            lossesTextBox.Size = new Size(100, 23);
            lossesTextBox.TabIndex = 23;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(462, 78);
            label14.Name = "label14";
            label14.Size = new Size(70, 15);
            label14.TabIndex = 24;
            label14.Text = "Мощность:";
            // 
            // powerTextBox
            // 
            powerTextBox.Location = new Point(454, 96);
            powerTextBox.Name = "powerTextBox";
            powerTextBox.Size = new Size(100, 23);
            powerTextBox.TabIndex = 25;
            // 
            // sectionTextBox
            // 
            sectionTextBox.Location = new Point(454, 149);
            sectionTextBox.Name = "sectionTextBox";
            sectionTextBox.Size = new Size(100, 23);
            sectionTextBox.TabIndex = 26;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(462, 131);
            label15.Name = "label15";
            label15.Size = new Size(57, 15);
            label15.TabIndex = 27;
            label15.Text = "Сечение:";
            // 
            // KoefComboBox
            // 
            KoefComboBox.FormattingEnabled = true;
            KoefComboBox.Location = new Point(454, 200);
            KoefComboBox.Name = "KoefComboBox";
            KoefComboBox.Size = new Size(101, 23);
            KoefComboBox.TabIndex = 28;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(462, 182);
            label16.Name = "label16";
            label16.Size = new Size(87, 15);
            label16.TabIndex = 29;
            label16.Text = "Коэффициент:";
            // 
            // button2
            // 
            button2.Location = new Point(454, 250);
            button2.Name = "button2";
            button2.Size = new Size(114, 45);
            button2.TabIndex = 30;
            button2.Text = "Рассчитать потери";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 461);
            Controls.Add(button2);
            Controls.Add(label16);
            Controls.Add(KoefComboBox);
            Controls.Add(label15);
            Controls.Add(sectionTextBox);
            Controls.Add(powerTextBox);
            Controls.Add(label14);
            Controls.Add(lossesTextBox);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(LEPlengthTextBox);
            Controls.Add(label11);
            Controls.Add(momentTextBox);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(tokTextBox);
            Controls.Add(specificPowerFullTextBox);
            Controls.Add(specificPowertextBox);
            Controls.Add(cosFTextBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(CalculateButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ConsumerTypesComboBox);
            Controls.Add(ConsumersCountTextBox);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Расчёт удельной мощности";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ConsumersCountTextBox;
        private ComboBox ConsumerTypesComboBox;
        private Label label2;
        private Label label3;
        private Button CalculateButton;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox cosFTextBox;
        private TextBox specificPowertextBox;
        private TextBox specificPowerFullTextBox;
        private TextBox tokTextBox;
        private Label label8;
        private Label label9;
        private Button button1;
        private Label label10;
        private TextBox momentTextBox;
        private Label label11;
        private TextBox LEPlengthTextBox;
        private Label label12;
        private Label label13;
        private TextBox lossesTextBox;
        private Label label14;
        private TextBox powerTextBox;
        private TextBox sectionTextBox;
        private Label label15;
        private ComboBox KoefComboBox;
        private Label label16;
        private Button button2;
    }
}
