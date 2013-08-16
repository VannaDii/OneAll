using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingListData.</summary>
	[DataContract()]
	public class SharingList : BaseObject
	{
		#region Member Variables

		/// <summary>The entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<SharingListEntry> _entries = new BaseCollection<SharingListEntry>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The entries.</summary>
		public BaseCollection<SharingListEntry> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}
