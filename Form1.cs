using RecipeBook.RecipeCreatorModules;

namespace RecipeBook
{
    public partial class Form1 : Form
    {
        private DbInteractor _dbInteractor;
        private RecipeContext _context;
        private Recipe _currentRecipe;

        public Form1()
        {
            InitializeComponent();

            // create a new database context
            InitializeDb();
            if (_dbInteractor != null)
            {
                Recipe[] recipes = _dbInteractor.GetAllRecipes().ToArray();
                List<ComboBoxItem> list = new List<ComboBoxItem>();
                foreach (Recipe recipe in recipes)
                {
                    list.Add(new ComboBoxItem(recipe.Name, recipe.RecipeId));
                }

                comboBox1.DataSource = list;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

                if (recipes.Length == 0)
                {
                    MessageBox.Show("No recipes found!");
                    return;
                }
                AmountInput.Value = 1;
            }
        }

        #region showing recipe

        private void RandomRecipeButton_Click(object sender, EventArgs e)
        {
            // pick a random recipe
            if (_dbInteractor != null)
            {
                Recipe[] recipes = _dbInteractor.GetAllRecipes().ToArray();

                if (recipes.Length == 0)
                {
                    MessageBox.Show("No recipes found!");
                    return;
                }

                Random random = new Random();
                Recipe randomRecipe = recipes[random.Next(recipes.Length)];

                AmountInput.Value = 1;

                _currentRecipe = randomRecipe;

                DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Database not connected!");
            }
        }

        private void InitializeDb()
        {
            using (var db = new RecipeContext())
            {
                if (db.Database.Exists())
                {
                    Console.WriteLine("Database connected successfully!");

                    _context = db;
                    _dbInteractor = new DbInteractor();

                    TotalDbInstancesLbl.Text = $"Total instances in database: {_dbInteractor.GetAllRecipes().Count}";
                }
            }
        }

        private void AddRecipeBtn_Click(object sender, EventArgs e)
        {
            // add a hardcoded recipe
            startupscreen scr = new startupscreen();
            scr.Show();
            scr.Location = this.Location;
            this.Hide();

            return;
        }

        private void DisplayRecipe()
        {
            if (_currentRecipe != null)
            {
                KcalLbl.Text = $"Total Kcal: {CalculateTotalKcal(_currentRecipe)}";
                //RecipeDescriptionLbl.Text = _currentRecipe.Description;

                RecipeStepBox.Items.Clear();
                foreach (Ingredient ingredient in _currentRecipe.Ingredients)
                {
                    string ingredientString = $"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit}";
                    if (ingredient.PlantAlternative != null && VeganOption.Checked)
                    {
                        ingredientString = $"{ingredient.PlantAlternative.Name} - {ingredient.PlantAlternative.Quantity} {ingredient.PlantAlternative.Unit}";
                    }
                    RecipeStepBox.Items.Add(ingredientString);
                }
                RecipeStepBox.Items.Add("Steps:_____________________________");
                foreach (Step step in _currentRecipe.Steps)
                {
                    RecipeStepBox.Items.Add(step.Description);
                    if (!string.IsNullOrEmpty(step.Tip))
                    {
                        RecipeStepBox.Items.Add($"---> Tip: {step.Tip}");
                    }
                }
            }
            else
            {
                MessageBox.Show("No recipe selected!");
            }
        }

        #region TestRecps
        /* private void CreateRecipe_1()
         {
             Recipe recipe = new Recipe();
             recipe.Name = "Vanille Milkshake";
             recipe.Description = "Hmmm lekker van de appie";
             // add ingredients per 1 person
             recipe.Ingredients = new List<Ingredient>
                 {
                     new Ingredient { Name = "Vanille Roomijs", Quantity = 240, Unit = Units.Gram.ToString(), Calories = 20 },
                     new Ingredient { Name = "Halvolle Melk", Quantity = 200, Unit = Units.Mililiter.ToString(),
                         PlantAlternative = new Ingredient{ Name = "Sojamelk", Quantity = 200, Unit = Units.Mililiter.ToString(), Calories = 70 }, Calories = 50 },
                     new Ingredient { Name = "Kristalsuiker", Quantity = 2, Unit = Units.EatingSpoon.ToString(), Calories = 10},
                     new Ingredient { Name = "Vanille Extract", Quantity = 0.25f, Unit = Units.TeaSpoon.ToString(), Calories = 2},
                 };
             recipe.Steps = new List<Step>
                 {
                     new Step { Description = "Doe het ijs, de melk, suiker en het vanille-extract in een blender en laat de blender kort draaien tot een romig en luchtig mengsel." },
                     new Step { Description = "Schenk de milkshake in de hoge glazen. Serveer met een rietje.", Tip = "Dit is een tip. een tip is top of flop" }
                 };

             _dbInteractor.AddRecipe(recipe);

             TotalDbInstancesLbl.Text = $"Total instances in database: {_dbInteractor.GetAllRecipes().Count}";
         }

         private void CreateRecipe_2()
         {
             Recipe recipe = new Recipe();
             recipe.Name = "Empanadas Gehakt";
             recipe.Description = "Recept voor empanadas (ervan uitgaan dat je al deeg hebt)";
             // add ingredients per 1 person
             recipe.Ingredients = new List<Ingredient>
                 {
                     new Ingredient { Name = "ui (gesnippert)", Quantity = 0.04f, Unit = Units.Piece.ToString(), Calories = 13},
                     new Ingredient { Name = "Knoflook (Tenen)", Quantity = 0.08f, Unit = Units.Piece.ToString(), Calories = 5},
                     new Ingredient { Name = "Gehakt", Quantity = 12, Unit = Units.Gram.ToString().ToLower(), Calories = 20,
                         PlantAlternative = new Ingredient { Name = "Vega vlees (eew)", Quantity = 12, Unit = Units.Gram.ToString(), Calories = 30 } },
                     new Ingredient { Name = "Gerookt paprikapoeder", Quantity = 0.04f, Unit = Units.TeaSpoon.ToString(), Calories = 4},
                     new Ingredient { Name = "Korianderpoeder", Quantity = 0.08f, Unit = Units.TeaSpoon.ToString(), Calories = 4},
                     new Ingredient { Name = "Oregano", Quantity = 0.04f, Unit = Units.TeaSpoon.ToString(), Calories = 4},
                     new Ingredient { Name = "Kurkuma", Quantity = 0.02f, Unit = Units.TeaSpoon.ToString(), Calories = 2},
                     new Ingredient { Name = "Gele paprika (Kleine blokjes)", Quantity = 0.04f, Unit = Units.Piece.ToString(), Calories = 4},
                     new Ingredient { Name = "Rode paprika (Kleine blokjes)", Quantity = 0.04f, Unit = Units.Piece.ToString(), Calories = 4},
                     new Ingredient { Name = "Ei (Geklutst)", Quantity = 0.04f, Unit = Units.Piece.ToString(), Calories = 8},
                     new Ingredient { Name = "Olijfolie, peper en zout", Quantity = 0, Unit = Units.Piece.ToString(), Calories = 0},
                 };
             recipe.Steps = new List<Step>
                 {
                     new Step { Description = "Zet een ruime koekenpan met wat olijfolie op het vuur en fruit de ui en knoflook even aan.", Tip = "Dit is een tip. een tip is top of flop" },
                     new Step { Description = "Voeg het gehakt toe, breng op smaak met de kruiden en bak rul." },
                     new Step { Description = "Voeg dan de gesneden paprika toe en bak tot de paprika zacht is. Breng verder op smaak met peper en zout en laat het mengsel afkoelen." },
                     new Step { Description = "Verwarm de oven voor op 225 graden." },
                     new Step { Description = "Vul deze met ongeveer 1 volle eetlepel van het gehaktmengsel, vouw dicht, druk de zijkanten goed aan (gebruik hiervoor eventueel een vork). Je kunt ook de uiteinden mooi vouwen zodat je zo'n mooi gevouwen randje krijgt. Herhaal dit tot het deeg en het gehakt op zijn." },
                     new Step { Description = "Leg de empanadas op een met bakpapier geklede bakplaat, bestrijk met het geklutste ei en bak de empandas (eventueel in delen) in ca. 12-15 minuten goudbruin. Serveer met een sausje naar wens. Eet smakelijk!" },
                 };

             _dbInteractor.AddRecipe(recipe);

             TotalDbInstancesLbl.Text = $"Total instances in database: {_dbInteractor.GetAllRecipes().Count}";
         }

         private void CreateRecipe_3()
         {
             Recipe recipe = new Recipe();
             recipe.Name = "Mango Smoothie";
             recipe.Description = "Recept van een of andere skere influencer-wannabe";
             // add ingredients per 1 person
             recipe.Ingredients = new List<Ingredient>
                     {
                         new Ingredient { Name = "Mango", Quantity = 400, Unit = Units.Gram.ToString(), Calories = 200},
                         new Ingredient { Name = "Griekse yoghurt (10% of vol)", Quantity = 250, Unit = Units.Gram.ToString(), Calories = 234},
                         new Ingredient { Name = "Limoensap", Quantity = 1, Unit = Units.Piece.ToString(), Calories = 4},
                     };
             recipe.Steps = new List<Step>
                     {
                         new Step { Description = "Doe alle ingrediënten samen in de blender en maal tot een gladde smoothie.", Tip = "Dit is een tip. een tip is top of flop"},
                         new Step { Description = "Proef even of de smoothie je bevalt en voeg eventueel extra mango, yoghurt of limoensap toe. Voor een dunnere smoothie voeg je 200 ml melk of sinaasappelsap toe." },
                         new Step { Description = "Verdeel de mango smoothie over twee grote glazen, met eventueel een rietje. Drink direct op." }
                     };

             _dbInteractor.AddRecipe(recipe);

             TotalDbInstancesLbl.Text = $"Total instances in database: {_dbInteractor.GetAllRecipes().Count}";
         }*/
        #endregion TestRecps
        private void RecipeStepBox_SelectedValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < RecipeStepBox.Items.Count - 1; i++)
            {
                if (RecipeStepBox.GetItemChecked(i))
                {
                    string s = RecipeStepBox.GetItemText(i);
                    s += "\u0336";
                }
                else
                {
                    string s = RecipeStepBox.GetItemText(i);
                    s.Replace("\u0336", "");
                }
            }
        }

        private void AmountInput_ValueChanged(object sender, EventArgs e)
        {
            if (_currentRecipe != null)
            {
                decimal pre_value = AmountInput.Value;
                int value = (int)Math.Round(pre_value, MidpointRounding.AwayFromZero);
                _currentRecipe = _currentRecipe.ChangeValuesByAmount(_dbInteractor.GetRecipe(_currentRecipe.RecipeId), value);
                _currentRecipe.PrepareAmount = value;
                DisplayRecipe();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dbInteractor != null)
            {
                AmountInput.Value = 1;

                if (comboBox1.SelectedIndex == -1 || comboBox1.Items.Count == 0)
                {
                    return;
                }

                if (comboBox1.SelectedValue == null)
                {
                    return;
                }
                ComboBoxItem selectedItem = comboBox1.SelectedItem as ComboBoxItem;
                _currentRecipe = _dbInteractor.GetRecipe(selectedItem.Id);

                DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Database not connected!");
            }
        }

        private void VeganOption_CheckedChanged(object sender, EventArgs e)
        {
            DisplayRecipe();
        }

        private int CalculateTotalKcal(Recipe recipe)
        {
            int totalKcal = 0;
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                totalKcal += ingredient.Calories;
            }
            //totalKcal = totalKcal * recipe.PrepareAmount;
            return totalKcal;
        }
        #endregion showing recipe

        #region adding recipe
        #endregion adding recipe
    }
}