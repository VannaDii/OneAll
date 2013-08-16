using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>Represents the access token on the source of the identity of the user on a connection.</summary>
	[DataContract(Name = "access_token")]
	public class AccessToken : BaseObject
	{
		#region Member Variables

		/// <summary>The key.</summary>
		private string _key;

		/// <summary>The secret.</summary>
		private string _secret;

		#endregion Member Variables

		#region Properties

		#region Key
		/// <summary>The key.</summary>
		[DataMember(Name = "key", IsRequired = false, EmitDefaultValue = false)]
		public string Key
		{
			get { return _key; }
			set { _key = value; OnPropertyChanged("Key"); }
		}
		#endregion Key

		#region Secret
		/// <summary>The secret.</summary>
		[DataMember(Name = "secret", IsRequired = false, EmitDefaultValue = false)]
		public string Secret
		{
			get { return _secret; }
			set { _secret = value; OnPropertyChanged("Secret"); }
		}
		#endregion Secret

		#endregion Properties
	}
}