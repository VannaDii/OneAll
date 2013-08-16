
namespace OneAll
{
	#region OneAllButtonStyle
	/// <summary>The styles of sharing buttons supported by the sharing plug-in.</summary>
	public enum OneAllButtonStyle
	{
		/// <summary>An invalid button style, this will result in the default (Small) being used.</summary>
		Invalid = 0,
		/// <summary>Display small buttons without counters.</summary>
		Small = 1,
		/// <summary>Display medium buttons without counters.</summary>
		Medium = 2,
		/// <summary>Display large buttons without counters.</summary>
		Large = 3,
		/// <summary>Display buttons with counters to the side.</summary>
		HorizontalCounter = 4,
		/// <summary>Display buttons with counters above them.</summary>
		VerticalCounter = 5
	}
	#endregion OneAllButtonStyle

	#region OneAllDirection
	/// <summary>The supported OneAll order directions.</summary>
	public enum OneAllDirection
	{
		/// <summary>An invalid order.</summary>
		Invalid = 0,
		/// <summary>An ascending order.</summary>
		Ascending = 1,
		/// <summary>A descending order.</summary>
		Descending = 2
	}
	#endregion OneAllDirection

	#region OneAllFormat
	/// <summary>The supported OneAll response formats.</summary>
	public enum OneAllFormat
	{
		/// <summary>The JSON format.</summary>
		Json = 0,
		/// <summary>The Xml format.</summary>
		Xml = 1
	}
	#endregion OneAllFormat

	#region OneAllMethod
	/// <summary>The valid OneAll HTTP methods.</summary>
	public enum OneAllMethod
	{
		/// <summary>An Invalid method.</summary>
		Invalid = 0,
		/// <summary>The Get method.</summary>
		Get = 1,
		/// <summary>The Post method.</summary>
		Post = 2,
		/// <summary>The Put method.</summary>
		Put = 3,
		/// <summary>The Delete method.</summary>
		Delete = 4
	}
	#endregion OneAllMethod

}