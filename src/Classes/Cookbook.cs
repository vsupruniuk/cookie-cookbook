using cookie_cookbook.AbstractClasses;
using cookie_cookbook.Enums;
using cookie_cookbook.Repositories;
using cookie_cookbook.Types;

namespace cookie_cookbook.Classes;

public class Cookbook : AbstractCookbook
{
	private const string FileName = "recipes";
	private const FileFormat FileFormat = Enums.FileFormat.Txt;
	private const string FilePath = $"./{FileName}";

	private readonly IngredientsRepository _ingredientsRepository;
	private readonly RecipeRepository _recipeRepository;
	private readonly Recipe _recipe;

	private List<int> _recipeIngredients = new List<int>();

	public Cookbook
		(
			IngredientsRepository ingredientsRepository, 
			RecipeRepository recipeRepository, 
			Recipe recipe
		)
	{
		_ingredientsRepository = ingredientsRepository;
		_recipeRepository = recipeRepository;
		_recipe = recipe;
	}

	public override void Open()
	{
		List<string> recipes = _recipeRepository.GetAllRecipes(FileFormat, FilePath);
		List<Ingredient> ingredients = _ingredientsRepository.GetAllIngredients();

		if (recipes.Count > 0)
		{
			_recipe.PrintSavedRecipes(recipes, ingredients);
		}

		Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

		_ingredientsRepository.PrintAllIngredients(ingredients);

		_recipeIngredients = _recipe.HandleIngredientsAdding(ingredients);

		if (_recipeIngredients.Count > 0)
		{
			_recipe.PrintRecipe(_recipeIngredients, ingredients);
		}

		_recipeRepository.SaveRecipe(_recipeIngredients, FileFormat, FilePath);

		Close();
	}

	public override void Close()
	{
		Console.WriteLine("Press any key to exit.");
		Console.ReadKey();
	}
}