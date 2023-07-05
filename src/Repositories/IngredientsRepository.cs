using System.Text.Json;
using cookie_cookbook.AbstractClasses.Repositories;
using cookie_cookbook.Types;

namespace cookie_cookbook.Repositories;

public class IngredientsRepository : AbstractIngredientsRepository
{
	public override List<Ingredient> GetAllIngredients()
	{
		string jsonData = File.ReadAllText("../../../src/Data/Ingredients.json");

		List<Ingredient> ingredientsFromJson = JsonSerializer.Deserialize<List<Ingredient>>(jsonData);

		return ingredientsFromJson;
	}

	public override void PrintAllIngredients(List<Ingredient> ingredients)
	{
		foreach (Ingredient ingredient in ingredients)
		{
			Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
		}
	}
}