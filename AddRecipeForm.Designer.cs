namespace RecipeBook
{
    partial class AddRecipeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecipeForm));
            NameTxtbx = new TextBox();
            StepTextbox = new TextBox();
            AddRecipeButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BackBtn = new Button();
            SuspendLayout();
            // 
            // NameTxtbx
            // 
            NameTxtbx.Location = new Point(60, 9);
            NameTxtbx.Name = "NameTxtbx";
            NameTxtbx.Size = new Size(100, 23);
            NameTxtbx.TabIndex = 0;
            NameTxtbx.TextChanged += NameTxtbx_TextChanged;
            // 
            // StepTextbox
            // 
            StepTextbox.Location = new Point(12, 88);
            StepTextbox.Multiline = true;
            StepTextbox.Name = "StepTextbox";
            StepTextbox.Size = new Size(830, 321);
            StepTextbox.TabIndex = 1;
            // 
            // AddRecipeButton
            // 
            AddRecipeButton.Location = new Point(415, 415);
            AddRecipeButton.Name = "AddRecipeButton";
            AddRecipeButton.Size = new Size(75, 23);
            AddRecipeButton.TabIndex = 2;
            AddRecipeButton.Text = "Add";
            AddRecipeButton.UseVisualStyleBackColor = true;
            AddRecipeButton.Click += AddRecipeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "Steps:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 9);
            label3.Name = "label3";
            label3.Size = new Size(678, 135);
            label3.TabIndex = 5;
            label3.Text = resources.GetString("label3.Text");
            // 
            // BackBtn
            // 
            BackBtn.Location = new Point(12, 415);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(75, 23);
            BackBtn.TabIndex = 6;
            BackBtn.Text = "Back";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // AddRecipeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 450);
            Controls.Add(BackBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AddRecipeButton);
            Controls.Add(StepTextbox);
            Controls.Add(NameTxtbx);
            Controls.Add(label3);
            Name = "AddRecipeForm";
            Text = "AddRecipeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTxtbx;
        private TextBox StepTextbox;
        private Button AddRecipeButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BackBtn;
    }
}