using System.Configuration;

namespace OneAll.Config
{
	/// <summary>Configuration settings for OneAll login and linking.</summary>
	public class AuthConfigElement : ConfigurationElement
	{
		#region Member Variables

		/// <summary>A private configuration property for the configured Link value.</summary>
		private ConfigurationProperty _link = new ConfigurationProperty("Link", typeof(DisplayConfigElement), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured Login value.</summary>
		private ConfigurationProperty _logOn = new ConfigurationProperty("LogOn", typeof(DisplayConfigElement), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured providers value.</summary>
		private ConfigurationProperty _providers = new ConfigurationProperty("Providers", typeof(ProviderConfigElementCollection), null, ConfigurationPropertyOptions.None);

		#endregion Member Variables

		#region Properties

		#region Link
		/// <summary>The configured Link value.</summary>
		[ConfigurationProperty("Link", DefaultValue = null)]
		public DisplayConfigElement Link
		{
			get { return (DisplayConfigElement)this[_link]; }
			set { this[_link] = value; }
		}
		#endregion Link

		#region Login
		/// <summary>The configured Login value.</summary>
		[ConfigurationProperty("LogOn", DefaultValue = null)]
		public DisplayConfigElement LogOn
		{
			get { return (DisplayConfigElement)this[_logOn]; }
			set { this[_logOn] = value; }
		}
		#endregion Login

		#region Providers
		/// <summary>The configured Providers value.</summary>
		[ConfigurationProperty("Providers", DefaultValue = null)]
		public ProviderConfigElementCollection Providers
		{
			get { return (ProviderConfigElementCollection)this[_providers]; }
		}
		#endregion Providers

		#endregion Properties
	}
}