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
            RecipeTitleLbl = new Label();
            RecipeStepBox = new CheckedListBox();
            AddRecipeBtn = new Button();
            TotalDbInstancesLbl = new Label();
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
            // RecipeTitleLbl
            // 
            RecipeTitleLbl.AutoSize = true;
            RecipeTitleLbl.Location = new Point(12, 9);
            RecipeTitleLbl.Name = "RecipeTitleLbl";
            RecipeTitleLbl.Size = new Size(38, 15);
            RecipeTitleLbl.TabIndex = 1;
            RecipeTitleLbl.Text = "label1";
            // 
            // RecipeStepBox
            // 
            RecipeStepBox.FormattingEnabled = true;
            RecipeStepBox.Location = new Point(12, 39);
            RecipeStepBox.Name = "RecipeStepBox";
            RecipeStepBox.Size = new Size(776, 364);
            RecipeStepBox.TabIndex = 2;
            // 
            // AddRecipeBtn
            // 
            AddRecipeBtn.Location = new Point(12, 415);
            AddRecipeBtn.Name = "AddRecipeBtn";
            AddRecipeBtn.Size = new Size(188, 23);
            AddRecipeBtn.TabIndex = 3;
            AddRecipeBtn.Text = "Add Recipe (hardcoded)";
            AddRecipeBtn.UseVisualStyleBackColor = true;
            AddRecipeBtn.Click += AddRecipeBtn_Click;
            // 
            // TotalDbInstancesLbl
            // 
            TotalDbInstancesLbl.AutoSize = true;
            TotalDbInstancesLbl.Location = new Point(594, 9);
            TotalDbInstancesLbl.Name = "TotalDbInstancesLbl";
            TotalDbInstancesLbl.Size = new Size(38, 15);
            TotalDbInstancesLbl.TabIndex = 4;
            TotalDbInstancesLbl.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TotalDbInstancesLbl);
            Controls.Add(AddRecipeBtn);
            Controls.Add(RecipeStepBox);
            Controls.Add(RecipeTitleLbl);
            Controls.Add(RandomRecipeButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RandomRecipeButton;
        private Label RecipeTitleLbl;
        private CheckedListBox RecipeStepBox;
        private Button AddRecipeBtn;
        private Label TotalDbInstancesLbl;
    }
}
