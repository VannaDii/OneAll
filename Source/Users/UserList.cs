using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll user list.</summary>
	[DataContract(Name = "users")]
	public class UserList : BaseObject
	{
		#region Member Variables

		/// <summary>The user entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<User> _entries = new BaseCollection<User>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The user entries.</summary>
		public BaseCollection<User> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}