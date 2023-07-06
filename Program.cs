using cookie_cookbook.Classes;
using cookie_cookbook.Repositories;

Cookbook cookbook = new Cookbook(new IngredientsRepository(), new RecipeRepository(), new Recipe(new Parser()));

cookbook.Open();