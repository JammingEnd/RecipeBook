namespace RecipeBook
{
    partial class Form1
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
            RandomRecipeButton = new Button();
            RecipeStepBox = new CheckedListBox();
            AddRecipeBtn = new Button();
            TotalDbInstancesLbl = new Label();
            KcalLbl = new Label();
            AmountInput = new NumericUpDown();
            comboBox1 = new ComboBox();
            VeganOption = new CheckBox();
            PdfBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)AmountInput).BeginInit();
            SuspendLayout();
            // 
            // RandomRecipeButton
            // 
            RandomRecipeButton.Location = new Point(305, 415);
            RandomRecipeButton.Name = "RandomRecipeButton";
            RandomRecipeButton.Size = new Size(188, 23);
            RandomRecipeButton.TabIndex = 0;
            RandomRecipeButton.Text = "Pick random Recipe";
            RandomRecipeButton.UseVisualStyleBackColor = true;
            RandomRecipeButton.Click += RandomRecipeButton_Click;
            // 
            // RecipeStepBox
            // 
            RecipeStepBox.FormattingEnabled = true;
            RecipeStepBox.Location = new Point(12, 39);
            RecipeStepBox.Name = "RecipeStepBox";
            RecipeStepBox.Size = new Size(776, 364);
            RecipeStepBox.TabIndex = 2;
            RecipeStepBox.SelectedValueChanged += RecipeStepBox_SelectedValueChanged;
            // 
            // AddRecipeBtn
            // 
            AddRecipeBtn.Location = new Point(12, 415);
            AddRecipeBtn.Name = "AddRecipeBtn";
            AddRecipeBtn.Size = new Size(188, 23);
            AddRecipeBtn.TabIndex = 3;
            AddRecipeBtn.Text = "Back";
            AddRecipeBtn.UseVisualStyleBackColor = true;
            AddRecipeBtn.Click += AddRecipeBtn_Click;
            // 
            // TotalDbInstancesLbl
            // 
            TotalDbInstancesLbl.AutoSize = true;
            TotalDbInstancesLbl.Location = new Point(628, 9);
            TotalDbInstancesLbl.Name = "TotalDbInstancesLbl";
            TotalDbInstancesLbl.Size = new Size(38, 15);
            TotalDbInstancesLbl.TabIndex = 4;
            TotalDbInstancesLbl.Text = "label1";
            // 
            // KcalLbl
            // 
            KcalLbl.AutoSize = true;
            KcalLbl.Location = new Point(283, 10);
            KcalLbl.Name = "KcalLbl";
            KcalLbl.Size = new Size(38, 15);
            KcalLbl.TabIndex = 5;
            KcalLbl.Text = "label1";
            // 
            // AmountInput
            // 
            AmountInput.Location = new Point(226, 7);
            AmountInput.Name = "AmountInput";
            AmountInput.Size = new Size(51, 23);
            AmountInput.TabIndex = 6;
            AmountInput.ValueChanged += AmountInput_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 7);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(208, 23);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // VeganOption
            // 
            VeganOption.AutoSize = true;
            VeganOption.Location = new Point(445, 10);
            VeganOption.Name = "VeganOption";
            VeganOption.Size = new Size(91, 19);
            VeganOption.TabIndex = 8;
            VeganOption.Text = "Plantaardig?";
            VeganOption.UseVisualStyleBackColor = true;
            VeganOption.CheckedChanged += VeganOption_CheckedChanged;
            // 
            // PdfBtn
            // 
            PdfBtn.Location = new Point(600, 415);
            PdfBtn.Name = "PdfBtn";
            PdfBtn.Size = new Size(188, 23);
            PdfBtn.TabIndex = 9;
            PdfBtn.Text = "Print Pdf";
            PdfBtn.UseVisualStyleBackColor = true;
            PdfBtn.Click += PdfBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PdfBtn);
            Controls.Add(VeganOption);
            Controls.Add(comboBox1);
            Controls.Add(AmountInput);
            Controls.Add(KcalLbl);
            Controls.Add(TotalDbInstancesLbl);
            Controls.Add(AddRecipeBtn);
            Controls.Add(RecipeStepBox);
            Controls.Add(RandomRecipeButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)AmountInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RandomRecipeButton;
        private CheckedListBox RecipeStepBox;
        private Button AddRecipeBtn;
        private Label TotalDbInstancesLbl;
        private Label KcalLbl;
        private NumericUpDown AmountInput;
        private ComboBox comboBox1;
        private CheckBox VeganOption;
        private Button PdfBtn;
    }
}
