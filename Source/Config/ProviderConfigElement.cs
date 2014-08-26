using System.Configuration;

namespace OneAll.Config
{
	/// <summary>Configuration settings for a OneAll provider.</summary>
	public class ProviderConfigElement : ConfigurationElement
	{
		#region Member Variables

		/// <summary>A private configuration property for the configured displayName value.</summary>
		private ConfigurationProperty _displayName = new ConfigurationProperty("displayName", typeof(string), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured name value.</summary>
		private ConfigurationProperty _name = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.None);

		#endregion Member Variables

		#region Properties

		#region DisplayName
		/// <summary>The configured displayName value.</summary>
		[ConfigurationProperty("displayName", DefaultValue = null)]
		public string DisplayName
		{
			get { return (string)this[_displayName]; }
			set { this[_displayName] = value; }
		}
		#endregion DisplayName

		#region Name
		/// <summary>The configured Name value.</summary>
		[ConfigurationProperty("name", DefaultValue = null)]
		public string Name
		{
			get { return (string)this[_name]; }
			set { this[_name] = value; }
		}
		#endregion Name

		#endregion Properties
	}
}