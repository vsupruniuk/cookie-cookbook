using cookie_cookbook.Types;

namespace cookie_cookbook.AbstractClasses.Repositories;

public abstract class AbstractIngredientsRepository
{
	public abstract List<Ingredient> GetAllIngredients();
	public abstract void PrintAllIngredients(List<Ingredient> ingredients);
}