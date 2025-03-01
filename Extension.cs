using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    public static class Extension
    {
        public static Recipe ChangeValuesByAmount(this Recipe recipe, Recipe original, int amount)
        {
            Recipe newRecipe = new Recipe();
            newRecipe.RecipeId = original.RecipeId;
            newRecipe.Name = recipe.Name;
            newRecipe.Description = recipe.Description;
            newRecipe.PrepareAmount = amount;

            newRecipe.Ingredients = new List<Ingredient>();
            newRecipe.Steps = recipe.Steps;

            foreach (Ingredient ingredient in original.Ingredients)
            {
                Ingredient newIngredient = new Ingredient();
                newIngredient.Name = ingredient.Name;
                newIngredient.Quantity = (float)Math.Round((double)(ingredient.Quantity * amount), 2);
                newIngredient.Calories = (int)Math.Round((double)(ingredient.Calories * amount), 0); // Kcal
                newIngredient.Unit = ingredient.Unit;
                newIngredient.RecipeId = newRecipe.RecipeId;

                if(ingredient.PlantAlternative != null)
                {
                    newIngredient.PlantAlternative = new Ingredient();
                    newIngredient.PlantAlternative.Name = ingredient.PlantAlternative.Name;
                    newIngredient.PlantAlternative.Quantity = (float)Math.Round((double)(ingredient.Quantity * amount), 2);
                    newIngredient.PlantAlternative.Calories = (int)Math.Round((double)(ingredient.Calories * amount), 0);
                    newIngredient.PlantAlternative.Unit = ingredient.PlantAlternative.Unit;
                    newIngredient.PlantAlternative.RecipeId = newRecipe.RecipeId;
                }

                newRecipe.Ingredients.Add(newIngredient);
            }

            

            return newRecipe;
        }

    }
}
