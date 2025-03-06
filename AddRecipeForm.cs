using RecipeBook.RecipeCreatorModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeBook
{
    public partial class AddRecipeForm : Form
    {
        private Recipe _newrecipe = new();

        private List<Ingredient> _ingredients = new();
        private List<Step> _steps = new();

        private int _Maxlines;
        private int _currentLineIndex = 0;

        bool _canAdd = true;

        public AddRecipeForm()
        {
            InitializeComponent();
        }

        private void NameTxtbx_TextChanged(object sender, EventArgs e)
        {
        }

        public void Reset()
        {
            _newrecipe = new();
            _ingredients = new();
            _steps = new();

            _Maxlines = 0;
            _currentLineIndex = 0;

            StepTextbox.Text = "::";
            StepTextbox.Lines[0] = "::";
        }

        private void SpliceTextToModel()
        {
            string line = StepTextbox.Lines[_currentLineIndex];

            // create step / ingr based on
            if (line.Length > 3)
            {
                string typeIdentity = line.Substring(0, 2);
                string content = line.Substring(2);

                if (StepTextbox.Lines[0].Contains("::"))
                {
                    _newrecipe.Description = StepTextbox.Lines[0].Replace("::", "");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Syntax incorrect, the first line should be :: which is the description", "Incorrect Syntax", MessageBoxButtons.OK);
                    StepTextbox.Lines[0] = "::";
                    _canAdd = false;
                    return;
                }

                if (typeIdentity.Contains("->") || typeIdentity.Contains("!-") || typeIdentity.Contains("::"))
                {
                    if (typeIdentity == "->")
                    {
                        // Base step
                        Step newStep = new();
                        newStep.Description = content;

                        if(_currentLineIndex + 1 <= StepTextbox.Lines.Length - 1)
                        {
                            if (StepTextbox.Lines[_currentLineIndex + 1].Contains("!>"))
                            {
                                newStep.Tip = StepTextbox.Lines[_currentLineIndex + 1].Substring(2);

                                // skip over this line in next interation
                                _currentLineIndex++;
                            }

                        }

                        _steps.Add(newStep);
                        return;
                    }

                    if (typeIdentity == "!-")
                    {
                        // Ingredient
                        Ingredient newIngredient = new();

                        string[] nameContent = content.Split(";");

                        if (nameContent.Length == 4)
                        {
                            nameContent[0].Replace(";", "");
                            nameContent[1].Replace(";", "");
                            newIngredient.Name = nameContent[0];
                            newIngredient.Unit = nameContent[2];
                            

                            if (Int32.TryParse(nameContent[1], out int result))
                            {
                                newIngredient.Quantity = (float)result;
                            }
                            else
                            {
                                DialogResult dr = MessageBox.Show("Cannot parse, Please only add numbers at the requested places", "Cannot Parse", MessageBoxButtons.OK);
                                _canAdd = false;
                                return;
                            }
                            if (Int32.TryParse(nameContent[3], out int Calresult))
                            {
                                newIngredient.Calories = Calresult;
                            }
                            else
                            {
                                DialogResult dr = MessageBox.Show("Cannot parse, Please only add numbers at the requested places", "Cannot Parse", MessageBoxButtons.OK);
                                _canAdd = false;
                                return;
                            }

                            if (StepTextbox.Lines[_currentLineIndex + 1].Contains(">>"))
                            {
                                Ingredient plantAlt = new();
                                string[] altContent = StepTextbox.Lines[_currentLineIndex + 1].Split(";");
                                if (altContent.Length == 4)
                                {
                                    altContent[0].Replace(">>", "");

                                    plantAlt.Name = altContent[0].Replace(">>", "");
                                    plantAlt.Unit = altContent[2];

                                    if (Int32.TryParse(nameContent[1], out int altResult))
                                    {
                                        plantAlt.Quantity = (float)altResult;
                                    }
                                    else
                                    {
                                        DialogResult dr = MessageBox.Show("Cannot parse, Please only add numbers at the requested places", "Cannot Parse", MessageBoxButtons.OK);
                                        _canAdd = false;
                                        return;
                                    }
                                    if (Int32.TryParse(nameContent[3], out int AltCalresult))
                                    {
                                        plantAlt.Calories = AltCalresult;
                                    }
                                    else
                                    {
                                        DialogResult dr = MessageBox.Show("Cannot parse, Please only add numbers at the requested places", "Cannot Parse", MessageBoxButtons.OK);
                                        _canAdd = false;
                                        return;
                                    }

                                    newIngredient.PlantAlternative = plantAlt;
                                    _currentLineIndex++;
                                }
                                else
                                {
                                    DialogResult dr = MessageBox.Show("Syntax incorrect, An Plant alternative ingredient should follow this layout: \n !-Soyamilk;125;ML", "Incorrect Syntax", MessageBoxButtons.OK);
                                    _canAdd = false;
                                    return;
                                }
                            }
                            _ingredients.Add(newIngredient);
                        }
                        else
                        {
                            // no good syntax
                            DialogResult dr = MessageBox.Show("Syntax incorrect, An ingredient should follow this layout: \n !-Paprika;10;Pieces", "Incorrect Syntax", MessageBoxButtons.OK);
                            _canAdd = false;
                        }

                        return;
                    }

                }
                else
                {
                    DialogResult dr = MessageBox.Show("Syntax incorrect detected or first instance is tip or plantAlt, An instance should begin with -> or !> ", "Incorrect Syntax", MessageBoxButtons.OK);
                    _canAdd = false;
                }

            }
        }

        private void AddRecipeButton_Click(object sender, EventArgs e)
        {
            _Maxlines = StepTextbox.Lines.Length;
            _canAdd = true;
            while (_currentLineIndex < _Maxlines)
            {
                SpliceTextToModel();

                if (!_canAdd)
                {
                    return;
                }

                _currentLineIndex++;
            }
            _newrecipe.Name = NameTxtbx.Text;
            _newrecipe.Ingredients = _ingredients;
            _newrecipe.Steps = _steps;
            AddToDatabase();

        }

        private void AddToDatabase()
        {
            using (var db = new RecipeContext())
            {
                if (db.Database.Exists())
                {
                    Console.WriteLine("Database connected successfully!");

                    DbInteractor q = new DbInteractor();
                    q.AddRecipe(_newrecipe);
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            startupscreen scr = new startupscreen();
            scr.Show();
            scr.Location = this.Location;
            this.Hide();

            return;
        }
    }
}