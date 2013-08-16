using System;
using System.Configuration;

namespace OneAll.Config
{
	/// <summary>The OneAll configuration section.</summary>
	public class ConfigSection : ConfigurationSection
	{
		#region Member Variables

		/// <summary>A private configuration property for the configured siteDomain value.</summary>
		private ConfigurationProperty _domain = new ConfigurationProperty("domain", typeof(Uri), null, ConfigurationPropertyOptions.IsRequired);

		/// <summary>A private configuration property for the configured privateKey value.</summary>
		private ConfigurationProperty _privateKey = new ConfigurationProperty("privateKey", typeof(string), null, ConfigurationPropertyOptions.IsRequired);

		/// <summary>A private configuration property for the configured publicKey value.</summary>
		private ConfigurationProperty _publicKey = new ConfigurationProperty("publicKey", typeof(string), null, ConfigurationPropertyOptions.IsRequired);

		/// <summary>A private configuration property for the configured Authentication value.</summary>
		private ConfigurationProperty _auth = new ConfigurationProperty("Authentication", typeof(AuthConfigElement), null, ConfigurationPropertyOptions.None);

		/// <summary>A private configuration property for the configured Sharing value.</summary>
		private ConfigurationProperty _sharing = new ConfigurationProperty("Sharing", typeof(SharingConfigElement), null, ConfigurationPropertyOptions.None);

		#endregion Member Variables

		#region Properties

		#region Domain
		/// <summary>The configured Domain value.</summary>
		[CallbackValidator(Type = typeof(ConfigValidator), CallbackMethodName = OneAllConstants.CONFIG_VALIDATOR_SECUREURI)]
		[ConfigurationProperty("domain", DefaultValue = null, IsRequired = true)]
		public Uri Domain
		{
			get { return (Uri)this[_domain]; }
			set { this[_domain] = value; }
		}
		#endregion Domain

		#region PrivateKey
		/// <summary>The configured PrivateKey value.</summary>
		[ConfigurationProperty("privateKey", DefaultValue = null, IsRequired = true)]
		public string PrivateKey
		{
			get { return (string)this[_privateKey]; }
			set { this[_privateKey] = value; }
		}
		#endregion PrivateKey

		#region PublicKey
		/// <summary>The configured PublicKey value.</summary>
		[ConfigurationProperty("publicKey", DefaultValue = null, IsRequired = true)]
		public string PublicKey
		{
			get { return (string)this[_publicKey]; }
			set { this[_publicKey] = value; }
		}
		#endregion PublicKey

		#region Authentication
		/// <summary>The configured Authentication value.</summary>
		[ConfigurationProperty("Authentication", DefaultValue = null)]
		public AuthConfigElement Authentication
		{
			get { return (AuthConfigElement)this[_auth]; }
			set { this[_auth] = value; }
		}
		#endregion Authentication

		#region Sharing
		/// <summary>The configured Sharing value.</summary>
		[ConfigurationProperty("Sharing", DefaultValue = null)]
		public SharingConfigElement Sharing
		{
			get { return (SharingConfigElement)this[_sharing]; }
			set { this[_sharing] = value; }
		}
		#endregion Sharing

		#endregion Properties
	}
}