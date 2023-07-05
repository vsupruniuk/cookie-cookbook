using cookie_cookbook.Enums;

namespace cookie_cookbook.AbstractClasses.Repositories;

public abstract class AbstractRecipeRepository
{
	public abstract List<string> GetAllRecipes(FileFormat fileFormat, string filePath);
	public abstract void SaveRecipe(List<int> ingredientsIds, FileFormat fileFormat, string filePath);
}