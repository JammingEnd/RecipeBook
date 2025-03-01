namespace RecipeBook
{
    public partial class Form1 : Form
    {
        private DbInteractor _dbInteractor;
        private RecipeContext _context;

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

                if (recipes.Length == 0)
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
                RecipeStepBox.Items.Add("");
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

                    _context = db;
                    _dbInteractor = new DbInteractor();

                    TotalDbInstancesLbl.Text = $"Total instances in database: {_dbInteractor.GetAllRecipes().Count}";
                }
            }
        }

        private void AddRecipeBtn_Click(object sender, EventArgs e)
        {
            // add a hardcoded recipe
            if (_dbInteractor != null)
            {
                CreateRecipe_1();
                CreateRecipe_2();
                CreateRecipe_3();
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Database not connected!");
            }
        }

        private void CreateRecipe_1()
        {
            Recipe recipe = new Recipe();
            recipe.Name = "Vanille Milkshake";
            recipe.Description = "Hmmm lekker van de appie";
            // add ingredients per 1 person
            recipe.Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Vanille Roomijs", Quantity = 240, Unit = Units.Gram.ToString()},
                    new Ingredient { Name = "Halvolle Melk", Quantity = 200, Unit = Units.Mililiter.ToString()},
                    new Ingredient { Name = "Kristalsuiker", Quantity = 2, Unit = Units.EatingSpoon.ToString()},
                    new Ingredient { Name = "Vanille Extract", Quantity = 0.25f, Unit = Units.TeaSpoon.ToString()},
                };
            recipe.Steps = new List<Step>
                {
                    new Step { Description = "Doe het ijs, de melk, suiker en het vanille-extract in een blender en laat de blender kort draaien tot een romig en luchtig mengsel." },
                    new Step { Description = "Schenk de milkshake in de hoge glazen. Serveer met een rietje." }
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
                    new Ingredient { Name = "ui (gesnippert)", Quantity = 0.04f, Unit = Units.Piece.ToString()},
                    new Ingredient { Name = "Knoflook (Tenen)", Quantity = 0.08f, Unit = Units.Piece.ToString()},
                    new Ingredient { Name = "Gehakt", Quantity = 12, Unit = Units.Gram.ToString()},
                    new Ingredient { Name = "Gerookt paprikapoeder", Quantity = 0.04f, Unit = Units.TeaSpoon.ToString()},
                    new Ingredient { Name = "Korianderpoeder", Quantity = 0.08f, Unit = Units.TeaSpoon.ToString()},
                    new Ingredient { Name = "Oregano", Quantity = 0.04f, Unit = Units.TeaSpoon.ToString()},
                    new Ingredient { Name = "Kurkuma", Quantity = 0.02f, Unit = Units.TeaSpoon.ToString()},
                    new Ingredient { Name = "Gele paprika (Kleine blokjes)", Quantity = 0.04f, Unit = Units.Piece.ToString()},
                    new Ingredient { Name = "Rode paprika (Kleine blokjes)", Quantity = 0.04f, Unit = Units.Piece.ToString()},
                    new Ingredient { Name = "Ei (Geklutst)", Quantity = 0.04f, Unit = Units.Piece.ToString()},
                    new Ingredient { Name = "Olijfolie, peper en zout", Quantity = 0, Unit = Units.Piece.ToString()},
                };
            recipe.Steps = new List<Step>
                {
                    new Step { Description = "Zet een ruime koekenpan met wat olijfolie op het vuur en fruit de ui en knoflook even aan." },
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
                        new Ingredient { Name = "Mango", Quantity = 400, Unit = Units.Gram.ToString()},
                        new Ingredient { Name = "Griekse yoghurt (10% of vol)", Quantity = 250, Unit = Units.Gram.ToString()},
                        new Ingredient { Name = "Limoensap", Quantity = 1, Unit = Units.Piece.ToString()},
                    };
            recipe.Steps = new List<Step>
                    {
                        new Step { Description = "Doe alle ingrediënten samen in de blender en maal tot een gladde smoothie." },
                        new Step { Description = "Proef even of de smoothie je bevalt en voeg eventueel extra mango, yoghurt of limoensap toe. Voor een dunnere smoothie voeg je 200 ml melk of sinaasappelsap toe." },
                        new Step { Description = "Verdeel de mango smoothie over twee grote glazen, met eventueel een rietje. Drink direct op." }
                    };

            _dbInteractor.AddRecipe(recipe);

            TotalDbInstancesLbl.Text = $"Total instances in database: {_dbInteractor.GetAllRecipes().Count}";
        }
    }
}