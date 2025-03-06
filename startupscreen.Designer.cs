namespace RecipeBook
{
    partial class startupscreen
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
            ShowRecipeBtn = new Button();
            AddRecipeBtn = new Button();
            SuspendLayout();
            // 
            // ShowRecipeBtn
            // 
            ShowRecipeBtn.Location = new Point(236, 48);
            ShowRecipeBtn.Name = "ShowRecipeBtn";
            ShowRecipeBtn.Size = new Size(362, 101);
            ShowRecipeBtn.TabIndex = 0;
            ShowRecipeBtn.Text = "Show recipes";
            ShowRecipeBtn.UseVisualStyleBackColor = true;
            ShowRecipeBtn.Click += ShowRecipeBtn_Click;
            // 
            // AddRecipeBtn
            // 
            AddRecipeBtn.Location = new Point(236, 199);
            AddRecipeBtn.Name = "AddRecipeBtn";
            AddRecipeBtn.Size = new Size(362, 109);
            AddRecipeBtn.TabIndex = 0;
            AddRecipeBtn.Text = "Add Recipe";
            AddRecipeBtn.Click += AddRecipeBtn_Click;
            // 
            // startupscreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddRecipeBtn);
            Controls.Add(ShowRecipeBtn);
            Name = "startupscreen";
            Text = "startupscreen";
            ResumeLayout(false);
        }

        #endregion

        private Button ShowRecipeBtn;
        private Button AddRecipeBtn;
    }
}