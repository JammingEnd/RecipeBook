namespace RecipeBook
{
    public partial class Form1 : Form
    {
        private DbInteractor _dbInteractor;
        public Form1()
        {
            InitializeComponent();

            // create a new database context
            InitializeDb();
        }

        private void RandomRecipeButton_Click(object sender, EventArgs e)
        {
            // pick a random recipe
            if (_dbInteractor != null)
            {
                Recipe[] recipes = _dbInteractor.GetAllRecipes().ToArray();

                if(recipes.Length == 0)
                {
                    MessageBox.Show("No recipes found!");
                    return;
                }

                Random random = new Random();
                Recipe randomRecipe = recipes[random.Next(recipes.Length)];

                RecipeTitleLbl.Text = randomRecipe.Name;
                RecipeStepBox.Items.Clear();
                foreach (Ingredient ingredient in randomRecipe.Ingredients)
                {
                    RecipeStepBox.Items.Add($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit}");
                }   
                foreach (Step step in randomRecipe.Steps)
                {
                    RecipeStepBox.Items.Add(step.Description);
                }
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

                    _dbInteractor = new DbInteractor();
                }
            }
        }

        private void AddRecipeBtn_Click(object sender, EventArgs e)
        {
            if(_dbInteractor != null)
            {
                Recipe recipe = new Recipe();
                recipe.Name = "Test Recipe";
                recipe.Description = "This is a test recipe";
                recipe.Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Paprika", Quantity = 1, Unit = "Piece"}
                };
                recipe.Steps = new List<Step>
                {
                    new Step { Description = "Do this lol" }
                };

                _dbInteractor.AddRecipe(recipe);
            }
            else
            {
                Console.WriteLine("Database not connected!");
            }
        }
    }
}
