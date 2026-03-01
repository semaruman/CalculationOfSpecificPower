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
            label3.Location = new Point(249, 310);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Результат";
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(226, 241);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(114, 45);
            CalculateButton.TabIndex = 5;
            CalculateButton.Text = "Рассчитать";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 350);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 6;
            label4.Text = "Итого кВт на 1 кв:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 374);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 7;
            label5.Text = "Итого кВт, Рр:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 403);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 8;
            label6.Text = "Ток:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(442, 78);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 9;
            label7.Text = "Cos ф";
            // 
            // cosFTextBox
            // 
            cosFTextBox.Location = new Point(427, 110);
            cosFTextBox.Name = "cosFTextBox";
            cosFTextBox.Size = new Size(74, 23);
            cosFTextBox.TabIndex = 10;
            cosFTextBox.Text = "0,98";
            // 
            // specificPowertextBox
            // 
            specificPowertextBox.Location = new Point(146, 342);
            specificPowertextBox.Name = "specificPowertextBox";
            specificPowertextBox.Size = new Size(100, 23);
            specificPowertextBox.TabIndex = 11;
            // 
            // specificPowerFullTextBox
            // 
            specificPowerFullTextBox.Location = new Point(146, 371);
            specificPowerFullTextBox.Name = "specificPowerFullTextBox";
            specificPowerFullTextBox.Size = new Size(100, 23);
            specificPowerFullTextBox.TabIndex = 12;
            // 
            // tokTextBox
            // 
            tokTextBox.Location = new Point(146, 400);
            tokTextBox.Name = "tokTextBox";
            tokTextBox.Size = new Size(100, 23);
            tokTextBox.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 461);
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
    }
}
