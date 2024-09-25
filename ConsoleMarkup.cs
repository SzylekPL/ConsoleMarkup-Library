namespace ConsoleMarkupLibrary;

public static class ConsoleMarkup
{
	private static readonly Dictionary<char, ConsoleColor> Tags = new();
	public static char TagIndicator { get; set; } = '/';
	public static char ResetTag { get; set; } = '#';
	public static void AddTag(char tagChar, ConsoleColor tagColor)
	{
		if (tagChar == TagIndicator || tagChar == ResetTag)
			throw new ArgumentException("Tag character cannot overlap with TagIndicator or ResetTag characters.");
		if (Tags.ContainsKey(tagChar))
			throw new ArgumentException($"Tag character {tagChar} is already assigned.");
		Tags.Add(tagChar, tagColor);
	}
	public static void Write(ReadOnlySpan<char> input)
	{
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == TagIndicator && i != input.Length - 2)
			{
				i++;
				if (Tags.TryGetValue(splitText[i], out ConsoleColor colorValue))
					Console.ForegroundColor = colorValue;
				else if (input[i] == TagIndicator || input[i] == ResetTag)
					Console.Write(splitText[i]);
				else
					throw new InvalidTagException($"The tag {splitText[i]} isn't defined in the Tags dictionary.");
			}
			else if (input[i] == ResetTag)
				Console.ResetColor();
			else
				Console.Write(splitText[i]);
		}
	}
	public static void WriteLine(string value) => Write(value + "\n");
}

public class InvalidTagException : Exception
{
	public InvalidTagException(string message) : base(message) { }
}
