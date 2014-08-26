using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A list of <see cref="SnapshotUrl" /> entries.</summary>
	[DataContract()]
	public class SnapshotUrlList : BaseObject
	{
		#region Member Variables

		/// <summary>The collection of entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<SnapshotUrl> _entries = new BaseCollection<SnapshotUrl>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The collection of entries.</summary>
		public BaseCollection<SnapshotUrl> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}