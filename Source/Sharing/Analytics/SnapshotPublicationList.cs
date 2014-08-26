using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A list of <see cref="SnapshotPublication" /> items.</summary>
	[DataContract()]
	public class SnapshotPublicationList : BaseObject
	{
		#region Member Variables

		/// <summary>The list of entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<SnapshotPublication> _entries = new BaseCollection<SnapshotPublication>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The list of entries.</summary>
		public BaseCollection<SnapshotPublication> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}