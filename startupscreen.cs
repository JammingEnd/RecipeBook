using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeBook
{
    public partial class startupscreen : Form
    {
        public startupscreen()
        {
            InitializeComponent();
        }

        private void ShowRecipeBtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Location = this.Location;
            form.StartPosition = this.StartPosition;
            form.FormClosing += delegate { this.Show(); };
            form.Show();
            this.Hide();
        }

        private void AddRecipeBtn_Click(object sender, EventArgs e)
        {
            AddRecipeForm form = new AddRecipeForm();
            form.Location = this.Location;
            form.StartPosition = this.StartPosition;
            form.FormClosing += delegate { this.Show(); };

            form.Reset();

            form.Show();
            this.Hide();
        }
    }
}