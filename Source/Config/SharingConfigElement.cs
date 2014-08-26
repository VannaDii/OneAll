using System;
using System.Configuration;

namespace OneAll.Config
{
	/// <summary>Configuration settings for OneAll sharing.</summary>
	public class SharingConfigElement : ConfigurationElement
	{
		#region Member Variables

		/// <summary>A private configuration property for the configured titleFormat value.</summary>
		private ConfigurationProperty _enableInsights = new ConfigurationProperty("enableInsights", typeof(bool), true, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured providers value.</summary>
		private ConfigurationProperty _providers = new ConfigurationProperty("Providers", typeof(ProviderConfigElementCollection), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured style value.</summary>
		private ConfigurationProperty _style = new ConfigurationProperty("style", typeof(OneAllButtonStyle), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured titleFormat value.</summary>
		private ConfigurationProperty _titleFormat = new ConfigurationProperty("titleFormat", typeof(string), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured URL value.</summary>
		private ConfigurationProperty _url = new ConfigurationProperty("url", typeof(Uri), null, ConfigurationPropertyOptions.None);

		#endregion Member Variables

		#region Properties

		#region EnableInsights
		/// <summary>The configured enableInsights value.</summary>
		[ConfigurationProperty("enableInsights", DefaultValue = true)]
		public bool EnableInsights
		{
			get { return (bool)this[_enableInsights]; }
			set { this[_enableInsights] = value; }
		}
		#endregion EnableInsights

		#region Providers
		/// <summary>The configured Providers value.</summary>
		[ConfigurationProperty("Providers", DefaultValue = null)]
		public ProviderConfigElementCollection Providers
		{
			get { return (ProviderConfigElementCollection)this[_providers]; }
		}
		#endregion Providers

		#region Style
		/// <summary>The configured style value.</summary>
		[ConfigurationProperty("style", DefaultValue = null)]
		public OneAllButtonStyle Style
		{
			get { return (OneAllButtonStyle)this[_style]; }
			set { this[_style] = value; }
		}
		#endregion Style

		#region TitleFormat
		/// <summary>The configured titleFormat value.</summary>
		[ConfigurationProperty("titleFormat", DefaultValue = null)]
		public string TitleFormat
		{
			get { return (string)this[_titleFormat]; }
			set { this[_titleFormat] = value; }
		}
		#endregion TitleFormat

		#region Url
		/// <summary>The configured url value.</summary>
		[ConfigurationProperty("url", DefaultValue = null)]
		public Uri Url
		{
			get { return (Uri)this[_url]; }
			set { this[_url] = value; }
		}
		#endregion Url

		#endregion Properties
	}
}