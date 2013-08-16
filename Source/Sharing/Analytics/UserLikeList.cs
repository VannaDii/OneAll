using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A list of <see cref="UserLike" /> entries.</summary>
	[DataContract()]
	public class UserLikeList : BaseObject
	{
		#region Member Variables

		/// <summary>The collection of entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<UserLike> _entries = new BaseCollection<UserLike>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The collection of entries.</summary>
		public BaseCollection<UserLike> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}
