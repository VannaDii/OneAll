using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A list of <see cref="UserComment" /> entries.</summary>
	[DataContract()]
	public class UserCommentList : BaseObject
	{
		#region Member Variables

		/// <summary>The collection of entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<UserComment> _entries = new BaseCollection<UserComment>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The collection of entries.</summary>
		public BaseCollection<UserComment> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}
