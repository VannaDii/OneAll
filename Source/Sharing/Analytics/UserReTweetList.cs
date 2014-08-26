using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A list of <see cref="UserReTweet" /> entries.</summary>
	[DataContract()]
	public class UserReTweetList : BaseObject
	{
		#region Member Variables

		/// <summary>The collection of entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<UserReTweet> _entries = new BaseCollection<UserReTweet>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The collection of entries.</summary>
		public BaseCollection<UserReTweet> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}
