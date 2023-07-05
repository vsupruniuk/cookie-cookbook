using System.Text.Json;
using cookie_cookbook.AbstractClasses.Repositories;
using cookie_cookbook.Enums;

namespace cookie_cookbook.Repositories;

public class RecipeRepository : AbstractRecipeRepository
{
	public override List<string> GetAllRecipes(FileFormat fileFormat, string filePath)
	{
		string fileExtension = fileFormat == FileFormat.Txt ? "txt" : "json";
		List<string> recipes = new List<string>();

		if ((fileFormat == FileFormat.Txt && File.Exists($"{filePath}.txt")) ||
		    (fileFormat == FileFormat.Json && File.Exists($"{filePath}.json")))
		{
			if (fileFormat == FileFormat.Txt)
			{
				string fileData = File.ReadAllText($"{filePath}.txt");

				recipes.AddRange(fileData.Split(Environment.NewLine).ToList());
			}
			else
			{
				string fileData = File.ReadAllText($"{filePath}.json");

				recipes.AddRange(JsonSerializer.Deserialize<List<string>>(fileData));
			}
		}

		return recipes;
	}

	public override void SaveRecipe(List<int> ingredientsIds, FileFormat fileFormat, string filePath)
	{
		if (ingredientsIds.Count == 0)
		{
			Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");

			return;
		}

		string ids = string.Join(",", ingredientsIds);

		if (fileFormat == FileFormat.Txt)
		{
			File.AppendAllText($"{filePath}.txt", $"{ids}{Environment.NewLine}");
		}
		else
		{
			List<string> recipes = new List<string> { ids };

			if (File.Exists($"{filePath}.json"))
			{
				string data = File.ReadAllText($"{filePath}.json");
				recipes.InsertRange(0, JsonSerializer.Deserialize<List<string>>(data));
			}

			string serializedData = JsonSerializer.Serialize(recipes);

			File.WriteAllText($"{filePath}.json", serializedData);
		}
	}
}