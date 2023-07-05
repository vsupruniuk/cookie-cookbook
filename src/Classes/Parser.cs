using cookie_cookbook.AbstractClasses;

namespace cookie_cookbook.Classes;

public class Parser : AbstractParser
{
	public override bool TryParseNumber(out int number)
	{
		string userInput = Console.ReadLine();

		if (int.TryParse(userInput, out number))
		{
			return false;
		}

		number = 0;

		return true;
	}
}