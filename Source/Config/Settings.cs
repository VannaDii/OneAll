using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace OneAll.Config
{
	/// <summary>The configured OneAll API settings.</summary>
	public sealed class Settings
	{
		#region Member Variables

		/// <summary>The configuration section.</summary>
		private ConfigSection _config = null;

		/// <summary>The <see cref="Credential" /> for these settings.</summary>
		private Credential _credential = null;

		/// <summary>The Domain value.</summary>
		private Uri _domain = null;

		/// <summary>Indicates if sharing insights are enabled (default: true) or not.</summary>
		private bool? _enableInsights = true;

		/// <summary>The single instance of the OneAll API settings.</summary>
		private static Settings _instance = null;

		/// <summary>The link display settings.</summary>
		private DisplaySettings _linkDisplay = null;

		/// <summary>The login display settings.</summary>
		private DisplaySettings _loginDisplay = null;

		/// <summary>Thread safety locking object.</summary>
		private static object _padLock = new object();

		/// <summary>The PrivateKey value.</summary>
		private string _privateKey = null;

		/// <summary>The array of providers names.</summary>
		private IEnumerable<string> _providerNames = null;

		/// <summary>The array of providers.</summary>
		private IEnumerable<Provider> _providers = null;

		/// <summary>The PublicKey value.</summary>
		private string _publicKey = null;

		/// <summary>The sharing URL value.</summary>
		private Uri _shareUrl = null;

		/// <summary>The style for the sharing buttons (default: small).</summary>
		private OneAllButtonStyle _sharingButtonStyle = OneAllButtonStyle.Small;

		/// <summary>The sharing title format value.</summary>
		private string _titleFormat = null;

		#endregion Member Variables

		#region Constructors

		/// <summary>Privately creates an instance of the OneAll API settings.</summary>
		private Settings() { InitializeConfig(); }

		#endregion Constructors

		#region Properties

		#region Credential
		/// <summary>The <see cref="Credential" /> for these settings.</summary>
		public Credential Credential
		{
			get { return _credential; }
		}
		#endregion Credential

		#region DisplayLink
		/// <summary>The link display values.</summary>
		public DisplaySettings DisplayLink
		{
			get
			{
				return (_linkDisplay == null ? (_config != null && _config.Authentication != null &&
					_config.Authentication.Link != null ? _config.Authentication.Link.AsSettings() : new DisplaySettings()) : _linkDisplay);
			}
			set { _linkDisplay = value; }
		}
		#endregion DisplayLink

		#region DisplayLogOn
		/// <summary>The login display values.</summary>
		public DisplaySettings DisplayLogOn
		{
			get
			{
				return (_loginDisplay == null ? (_config != null && _config.Authentication != null &&
					_config.Authentication.LogOn != null ? _config.Authentication.LogOn.AsSettings() : new DisplaySettings()) : _loginDisplay);
			}
			set { _loginDisplay = value; }
		}
		#endregion DisplayLogOn

		#region Domain
		/// <summary>The Domain value.</summary>
		public Uri Domain
		{
			get { return (_domain == null ? (_config != null ? _config.Domain : null) : _domain); }
			set { _domain = value; }
		}
		#endregion Domain

		#region EnableInsights
		/// <summary>Indicates if sharing insights are enabled (default: true) or not.</summary>
		public bool? EnableInsights
		{
			get { return (_enableInsights == null ? (_config != null && _config.Sharing != null ? _config.Sharing.EnableInsights : true) : _enableInsights); }
			set { _enableInsights = value; }
		}
		#endregion EnableInsights

		#region Instance
		/// <summary>Gets the single instance of the API settings.</summary>
		public static Settings Instance
		{
			get
			{
				lock (_padLock)
				{
					if (_instance == null)
						_instance = new Settings();
				}

				return _instance;
			}
		}
		#endregion Instance

		#region PrivateKey
		/// <summary>The PrivateKey value.</summary>
		public string PrivateKey
		{
			get { return (string.IsNullOrEmpty(_privateKey) ? (_config != null ? _config.PrivateKey : string.Empty) : _privateKey); }
			set
			{
				_privateKey = value;
				SetCredential();
			}
		}
		#endregion PrivateKey

		#region ProviderNames
		/// <summary>The ProviderNames values.</summary>
		public IEnumerable<string> ProviderNames
		{
			get
			{
				return (_providerNames == null || _providerNames.Count() < 1 ? (_config != null &&
					_config.Authentication != null && _config.Authentication.Providers != null ? _config.Authentication.Providers.AllNames() : new string[0]) : _providerNames);
			}
			set { _providerNames = value; }
		}
		#endregion ProviderNames

		#region Providers
		/// <summary>The Provider values.</summary>
		public IEnumerable<Provider> Providers
		{
			get
			{
				return (_providers == null || _providers.Count() < 1 ? (_config != null &&
					_config.Sharing != null && _config.Sharing.Providers != null && _config.Sharing.Providers.Count > 0 ?
						_config.Sharing.Providers.AllProviders() : new Provider[0]) : _providers);
			}
			set { _providers = value; }
		}
		#endregion Providers

		#region PublicKey
		/// <summary>The PublicKey value.</summary>
		public string PublicKey
		{
			get { return (string.IsNullOrEmpty(_publicKey) ? (_config != null ? _config.PublicKey : string.Empty) : _publicKey); }
			set
			{
				_publicKey = value;
				SetCredential();
			}
		}
		#endregion PublicKey

		#region ShareUrl
		/// <summary>The sharing URL value.</summary>
		public Uri ShareUrl
		{
			get { return (_shareUrl == null ? (_config != null && _config.Sharing != null ? _config.Sharing.Url : null) : _shareUrl); }
			set { _shareUrl = value; }
		}
		#endregion ShareUrl

		#region SharingButtonStyle
		/// <summary>The style for the sharing buttons (default: small).</summary>
		public OneAllButtonStyle SharingButtonStyle
		{
			get { return (OneAllButtonStyle.Invalid.Equals(_sharingButtonStyle) ? (_config != null && _config.Sharing != null ? _config.Sharing.Style : OneAllButtonStyle.Small) : _sharingButtonStyle); }
			set { _sharingButtonStyle = value; }
		}
		#endregion SharingButtonStyle

		#region TitleFormat
		/// <summary>The sharing title format value.</summary>
		public string TitleFormat
		{
			get { return (string.IsNullOrEmpty(_titleFormat) ? (_config != null && _config.Sharing != null ? _config.Sharing.TitleFormat : null) : _titleFormat); }
			set { _titleFormat = value; }
		}
		#endregion TitleFormat

		#endregion Properties

		#region Methods

		#region GetInstance
		/// <summary>Gets a new instance of the settings.</summary>
		/// <returns>A new <see cref="Settings" /> instance.</returns>
		internal static Settings GetInstance()
		{
			return new Settings();
		}
		#endregion GetInstance

		#region InitializeConfig
		/// <summary>Initializes the settings from the current configuration.</summary>
		internal void InitializeConfig()
		{
			object section = null;
			try { section = ConfigurationManager.GetSection(OneAllConstants.CONFIG_SECTION_NAME); }
			catch
			{
				section = null;
				throw;
			}

			if (section != null)
			{
				_config = section as ConfigSection;
				SetCredential();
			}
		}
		#endregion InitializeConfig

		#region InitializeValues
		/// <summary>Initializes the instance with the specified values. These values will override any configured values.</summary>
		/// <param name="domain">The domain to be used, or null to use the configured value.</param>
		/// <param name="privateKey">The private key to be used, or null to use the configured value.</param>
		/// <param name="publicKey">The public key to be used, or null to use the configured value.</param>
		/// <param name="logOnDisplay">The display settings for the log on script.</param>
		/// <param name="linkDisplay">The display settings for the link/connect script.</param>
		/// <param name="authProviders">The provider names which will be supported for authentication.</param>
		/// <param name="shareProviders">The providers which will be supported for sharing.</param>
		internal void InitializeValues(Uri domain, string privateKey, string publicKey, DisplaySettings logOnDisplay, DisplaySettings linkDisplay, IEnumerable<string> authProviders, IEnumerable<Provider> shareProviders)
		{
			if (domain != null && domain.IsAbsoluteUri && !domain.Scheme.Equals(Uri.UriSchemeHttps))
				throw new ArgumentException("The specified OneAll API domain does not use an HTTPS scheme. A correct OneAll API domain must use the HTTPS scheme.", "domain");

			_domain = domain;
			_privateKey = privateKey;
			_publicKey = publicKey;
			_loginDisplay = logOnDisplay;
			_linkDisplay = linkDisplay;
			_providerNames = authProviders;
			_providers = shareProviders;

			SetCredential();
		}
		#endregion InitializeValues

		#region SetCredential
		/// <summary>Sets the credential for this settings instance.</summary>
		private void SetCredential() { _credential = new Credential(this); }
		#endregion SetCredential

		#endregion Methods
	}
}