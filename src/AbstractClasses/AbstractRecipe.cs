using cookie_cookbook.Types;

namespace cookie_cookbook.AbstractClasses;

public abstract class AbstractRecipe
{
	public abstract List<int> HandleIngredientsAdding(List<Ingredient> ingredients);
	public abstract void PrintRecipe(List<int> ingredientsIds, List<Ingredient> ingredients);
	public abstract void PrintSavedRecipes(List<string> recipes, List<Ingredient> ingredients);
}