using cookie_cookbook.AbstractClasses;
using cookie_cookbook.Types;

namespace cookie_cookbook.Classes;

public class Recipe : AbstractRecipe
{
	private readonly Parser _parser = new Parser();

	public override List<int> HandleIngredientsAdding(List<Ingredient> ingredients)
	{
		List<int> selectedIngredients = new List<int>();
		bool isIngredientsAdded = false;
		int selectedIngredientId;

		while (!isIngredientsAdded)
		{
			Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");

			isIngredientsAdded = _parser.TryParseNumber(out selectedIngredientId);

			if (ingredients.FindIndex(i => i.Id == selectedIngredientId) >= 0)
			{
				selectedIngredients.Add(selectedIngredientId);
			}
		}

		return selectedIngredients;
	}

	public override void PrintRecipe(List<int> ingredientsIds, List<Ingredient> ingredients)
	{
		Console.WriteLine("Recipe added:");

		foreach (int id in ingredientsIds)
		{
			Ingredient ingredient = ingredients.Find(i => i.Id == id);

			Console.WriteLine($"{ingredient.Name}. {ingredient.PreparationInstructions}");
		}
	}

	public override void PrintSavedRecipes(List<string> recipes, List<Ingredient> ingredients)
	{
		Console.WriteLine("Existing recipes are:");

		for (int i = 0; i < recipes.Count; i += 1)
		{
			if (recipes[i].Length > 0)
			{
				string[] recipeIds = recipes[i].Split(",");

				Console.WriteLine($"*****{i + 1}*****");

				foreach (string id in recipeIds)
				{
					Ingredient ingredient = ingredients.Find(i => i.Id == int.Parse(id));

					Console.WriteLine($"{ingredient.Name}. {ingredient.PreparationInstructions}");
				}
			}
		}
	}
}