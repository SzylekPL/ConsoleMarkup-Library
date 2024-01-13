# ConsoleMarkup
## This small C# Console App library makes it easier to use colors in the console by adding a tag system.
## Content:
### - ConsoleMarkup static class that encapsulates all the funtionality;
### - AddTag(char tagChar, ConsoleColor tagColor) method to add a new tag;
### - TagIndicator and ResetTag properties for customizing special characters. Default values are'/' and '#', respectively. TagIndicator also acts as a negation character when used before ResetTag or another Tag indicator characters to write them in the standard manner.
### - Write and WriteLine methods to write text using color tags.
## Usage Example:
```cs
using ConsoleMarkupLibrary; // Linking library.
static void Main()
{
	ConsoleMarkup.AddTag('Y', ConsoleColor.DarkYellow); // Creation of the new tag.
	ConsoleMarkup.Write("Test /YTest# Test"); // As the result the middle Test will be written in the dark yellow color.
}
```
