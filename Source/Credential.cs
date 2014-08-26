using System.Security;
using OneAll.Config;

namespace OneAll
{
	/// <summary>Credentials used for some operations of the OneAll API.</summary>
	public class Credential
	{
		#region Member Variables

		/// <summary>The default credential.</summary>
		private static Credential _default = null;

		/// <summary>A safety lock on the default credential.</summary>
		private static object _defaultLock = new object();

		#endregion Member Variables

		#region Constructors

		/// <summary>Creates a new instance of <see cref="Credential" />.</summary>
		/// <param name="publicKey">The public key value.</param>
		/// <param name="privateKey">The private key value.</param>
		internal Credential(string publicKey, string privateKey)
		{
			PublicKey = publicKey;
			PrivateKey = new SecureString();
			foreach (char c in privateKey) PrivateKey.AppendChar(c);
		}

		/// <summary>Creates a new instance of <see cref="Credential" />.</summary>
		/// <param name="settings">The <see cref="Settings"/> containing the keys.</param>
		internal Credential(Settings settings)
		{
			if (settings != null)
			{
				PublicKey = settings.PublicKey;
				PrivateKey = new SecureString();
				foreach (char c in settings.PrivateKey) PrivateKey.AppendChar(c);
			}
		}

		#endregion Constructors

		#region Properties

		#region Default
		/// <summary>The default OneAll credential based on the currently initialized settings.</summary>
		public static Credential Default
		{
			get
			{
				lock (_defaultLock)
				{
					if (_default == null)
						_default = new Credential(Settings.Instance.PublicKey, Settings.Instance.PrivateKey);
				}
				return _default;
			}
		}
		#endregion Default

		#region PrivateKey
		/// <summary>A OneAll Private Key.</summary>
		public SecureString PrivateKey { get; set; }
		#endregion PrivateKey

		#region PublicKey
		/// <summary>A OneAll Public Key.</summary>
		public string PublicKey { get; set; }
		#endregion PublicKey

		#endregion Properties

		#region Methods

		#region IsValid
		/// <summary>Indicates if the credential is valid or not.</summary>
		/// <returns>True if the credential is valid, otherwise false.</returns>
		internal bool IsValid() { return (!string.IsNullOrEmpty(PublicKey) && (PrivateKey != null && PrivateKey.Length > 0)); }
		#endregion IsValid

		#endregion Methods
	}
}