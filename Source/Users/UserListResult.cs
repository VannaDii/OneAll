using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>The data object for a OneAll user list.</summary>
	[DataContract(Name = "data")]
	public class UserListResult : BaseObject
	{
		#region Member Variables

		/// <summary>The users.</summary>
		private UserList __users = new UserList();

		#endregion Member Variables

		#region Properties

		#region Users
		/// <summary>The users.</summary>
		[DataMember(Name = "users", IsRequired = false, EmitDefaultValue = false)]
		public UserList Users
		{
			get { return __users; }
			set
			{
				__users = value;
				OnPropertyChanged("Users");
			}
		}
		#endregion Users

		#endregion Properties
	}
}
