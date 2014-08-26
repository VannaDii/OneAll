using System;
using System.Runtime.Serialization;
using OneAll.Users;

namespace OneAll.Connections
{
	/// <summary>Represents the user on a connection.</summary>
	[DataContract(Name = "user")]
	public class ConnectionUser : BaseObject
	{
		#region Member Variables

		/// <summary>The identity.</summary>
		private Identity _identity;

		/// <summary>The user token.</summary>
		private Guid _userToken;

		/// <summary>The uuid.</summary>
		private Guid _uuid;

		#endregion Member Variables

		#region Properties

		#region Identity
		/// <summary>The identity.</summary>
		[DataMember(Name = "identity", IsRequired = false, EmitDefaultValue = false)]
		public Identity Identity
		{
			get { return _identity; }
			set { _identity = value; OnPropertyChanged("Identity"); }
		}
		#endregion Identity

		#region UserToken
		/// <summary>The user token.</summary>
		[DataMember(Name = "user_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid UserToken
		{
			get { return _userToken; }
			set { _userToken = value; OnPropertyChanged("UserToken"); }
		}
		#endregion UserToken

		#region UUID
		/// <summary>The UUID.</summary>
		[DataMember(Name = "uuid", IsRequired = false, EmitDefaultValue = false)]
		public Guid UUID
		{
			get { return _uuid; }
			set { _uuid = value; OnPropertyChanged("UUID"); }
		}
		#endregion UUID

		#endregion Properties
	}
}