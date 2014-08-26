using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>Represents an account entry in a list.</summary>
	[DataContract()]
	public class AccountEntry : BaseObject
	{
		#region Member Variables

		/// <summary>The domain.</summary>
		private string _domain;

		/// <summary>The user id.</summary>
		private string _userId;

		/// <summary>The user name.</summary>
		private string _userName;

		#endregion Member Variables

		#region Properties

		#region Domain
		/// <summary>The domain.</summary>
		[DataMember(Name = "domain", IsRequired = false, EmitDefaultValue = false)]
		public string Domain
		{
			get { return _domain; }
			set { _domain = value; OnPropertyChanged("Domain"); }
		}
		#endregion Domain

		#region UserId
		/// <summary>The user id.</summary>
		[DataMember(Name = "userid", IsRequired = false, EmitDefaultValue = false)]
		public string UserId
		{
			get { return _userId; }
			set { _userId = value; OnPropertyChanged("UserId"); }
		}
		#endregion UserId

		#region UserName
		/// <summary>The user name.</summary>
		[DataMember(Name = "username", IsRequired = false, EmitDefaultValue = false)]
		public string UserName
		{
			get { return _userName; }
			set { _userName = value; OnPropertyChanged("UserName"); }
		}
		#endregion UserName

		#endregion Properties
	}
}