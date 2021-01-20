/// <summary>
/// String extension method utility for Rich Text options.
/// For more information about Rich Text in Unity: https://docs.unity3d.com/Manual/StyledText.html
/// </summary>
public static class RichTextUtility
{
	public const string WhiteHex = "FFFFFFFF";
	public const string BlackHex = "00000000";

	/// <summary>
	/// Return this text with italicized rich text.
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public static string ItalicizeText(this string text)
	{
		return "<i>" + text + "</i>";
	}

	/// <summary>
	/// Return this text with bold rich text.
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public static string BoldText(this string text)
	{
		return "<b>" + text + "</b>";
	}

	/// <summary>
	/// Return this text with rich text changing the size to the specified size.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="size"></param>
	/// <returns></returns>
	public static string ResizeText(this string text, int size)
	{
		return "<size=" + size + ">" + text + "</size>";
	}

	/// <summary>
	/// Return this text with rich text changing the color to the specified color option.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="color"></param>
	/// <returns></returns>
	public static string ColorText(this string text, RichTextColor color)
	{
		return "<color=" + color.ToString() + ">" + text + "</color>";
	}

	/// <summary>
	/// Return this text with rich text changing the color to the specified hex color option.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="hexColor"></param>
	/// <returns></returns>
	public static string ColorText(this string text, string hexColor)
	{
		return "<color=#" + hexColor + ">" + text + "</color>";
	}

	/// <summary>
	/// Return this text with rich text changing the color to the specified Unity color.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="color"></param>
	/// <returns></returns>
	public static string ColorText(this string text, Color color)
	{
		return text.ColorText(ColorUtility.ToHtmlStringRGBA(color));
	}
}
