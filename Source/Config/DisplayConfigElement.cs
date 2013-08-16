using System;
using System.Configuration;

namespace OneAll.Config
{
	/// <summary>Configuration settings for OneAll login and linking web UI.</summary>
	public class DisplayConfigElement : ConfigurationElement
	{
		#region Member Variables

		/// <summary>A private configuration property for the configured callback value.</summary>
		private ConfigurationProperty _callback = new ConfigurationProperty("callback", typeof(Uri), null, ConfigurationPropertyOptions.IsRequired);

		/// <summary>A private configuration property for the configured height value.</summary>
		private ConfigurationProperty _height = new ConfigurationProperty("height", typeof(int), 0, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured theme value.</summary>
		private ConfigurationProperty _theme = new ConfigurationProperty("theme", typeof(string), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured width value.</summary>
		private ConfigurationProperty _width = new ConfigurationProperty("width", typeof(int), 0, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured same_window value.</summary>
		private ConfigurationProperty _sameWindow = new ConfigurationProperty("sameWindow", typeof(int), 0, ConfigurationPropertyOptions.None);

		#endregion Member Variables

		#region Properties

		#region Callback
		/// <summary>The configured Callback value.</summary>
		[ConfigurationProperty("callback", DefaultValue = null, IsRequired = true)]
		public Uri Callback
		{
			get { return (Uri)this[_callback]; }
			set { this[_callback] = value; }
		}
		#endregion Callback

		#region Height
		/// <summary>The configured Height value.</summary>
		[ConfigurationProperty("height", DefaultValue = 0)]
		public int Height
		{
			get { return (int)this[_height]; }
			set { this[_height] = value; }
		}
		#endregion Height

		#region Theme
		/// <summary>The configured Theme value.</summary>
		[ConfigurationProperty("theme", DefaultValue = null)]
		public string Theme
		{
			get { return (string)this[_theme]; }
			set { this[_theme] = value; }
		}
		#endregion Theme

		#region Width
		/// <summary>The configured Width value.</summary>
		[ConfigurationProperty("width", DefaultValue = 0)]
		public int Width
		{
			get { return (int)this[_width]; }
			set { this[_width] = value; }
		}
		#endregion Width

		#region SameWindow
		/// <summary>The configured sameWindow value.</summary>
		[ConfigurationProperty("sameWindow", DefaultValue = false)]
		public bool SameWindow
		{
			get { return (bool)this[_sameWindow]; }
			set { this[_sameWindow] = value; }
		}
		#endregion SameWindow

		#endregion Properties

		/// <summary>Gets this instance as a settings object.</summary>
		/// <returns>A <see cref="DisplaySettings"/> object.</returns>
		internal DisplaySettings AsSettings()
		{
			return new DisplaySettings()
			{
				SameWindow = SameWindow,
				Callback = Callback,
				Height = Height,
				Theme = Theme,
				Width = Width
			};
		}
	}
}