using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll user data.</summary>
	[DataContract()]
	public class UserResult : BaseObject
	{
		#region Member Variables

		/// <summary>The user.</summary>
		private User _user;

		#endregion Member Variables

		#region Properties

		#region User
		/// <summary>The user.</summary>
		[DataMember(Name = "user", IsRequired = false, EmitDefaultValue = false)]
		public User User
		{
			get { return _user; }
			set { _user = value; OnPropertyChanged("User"); }
		}
		#endregion User

		#endregion Properties
	}
}