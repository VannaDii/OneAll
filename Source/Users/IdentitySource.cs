using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll identity source.</summary>
	[DataContract()]
	public class IdentitySource : BaseObject
	{
		#region Member Variables

		/// <summary>The key.</summary>
		private string _key;

		/// <summary>The name.</summary>
		private string _name;

		/// <summary>The access token.</summary>
		private AccessToken _accessToken;

		#endregion Member Variables

		#region Properties

		#region AccessToken
		/// <summary>The access token.</summary>
		[DataMember(Name = "access_token", IsRequired = false, EmitDefaultValue = false)]
		public AccessToken AccessToken
		{
			get { return _accessToken; }
			set { _accessToken = value; OnPropertyChanged("AccessToken"); }
		}
		#endregion AccessToken

		#region Key
		/// <summary>The key.</summary>
		[DataMember(Name = "key", IsRequired = false, EmitDefaultValue = false)]
		public string Key
		{
			get { return _key; }
			set { _key = value; OnPropertyChanged("Key"); }
		}
		#endregion Key

		#region Name
		/// <summary>The name.</summary>
		[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
		public string Name
		{
			get { return _name; }
			set { _name = value; OnPropertyChanged("Name"); }
		}
		#endregion Name

		#endregion Properties
	}
}