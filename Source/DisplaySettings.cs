using System;

namespace OneAll
{
	/// <summary>OneAll Web UI Display Settings.</summary>
	public class DisplaySettings
	{
		#region Member Variables

		/// <summary>The relative or absolute callback URL.</summary>
		private Uri _callback = null;

		/// <summary>The number of items to display vertically.</summary>
		private int _height = 0;

		/// <summary>The theme, or CSS URL, to use.</summary>
		private string _theme = string.Empty;

		/// <summary>The number of items to display horizontally.</summary>
		private int _width = 0;

		/// <summary>True if the action will be processed in the same window, otherwise false.</summary>
		private bool _sameWindow = false;

		#endregion Member Variables

		#region Properties

		#region Callback
		/// <summary>The relative or absolute callback URL.</summary>
		public Uri Callback
		{
			get { return _callback; }
			set { _callback = value; }
		}
		#endregion Callback

		#region Height
		/// <summary>The number of items to display vertically.</summary>
		public int Height
		{
			get { return _height; }
			set { _height = value; }
		}
		#endregion Height

		#region Theme
		/// <summary>The theme, or CSS URL, to use.</summary>
		public string Theme
		{
			get { return _theme; }
			set { _theme = value; }
		}
		#endregion Theme

		#region Width
		/// <summary>The number of items to display horizontally.</summary>
		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}
		#endregion Width

		#region SameWindow
		/// <summary>True if the action will be processed in the same window, otherwise false.</summary>
		public bool SameWindow
		{
			get { return _sameWindow; }
			set { _sameWindow = value; }
		}
		#endregion SameWindow

		#endregion Properties
	}
}