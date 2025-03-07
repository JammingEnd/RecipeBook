SELECT 
    r.RecipeId,
    r.Name AS RecipeName,
    r.Description AS RecipeDescription,
    i.Name AS IngredientName,
    i.Quantity,
    i.Unit,
    s.Description AS StepDescription,
    s.StepId
FROM 
    Recipes r
FULL OUTER JOIN 
    Ingredients i ON r.RecipeId = i.RecipeId
FULL OUTER JOIN 
    Steps s ON r.RecipeId = s.RecipeId
ORDER BY 
    r.RecipeId, s.StepId;

