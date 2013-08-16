using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A list of sharing analytics snapshots.</summary>
	[DataContract()]
	public class SnapshotList : BaseObject
	{
		#region Member Variables

		/// <summary>A list of basic snapshots information.</summary>
		[DataMember(Name = "entries", IsRequired = true, EmitDefaultValue = false)]
		private BaseCollection<Snapshot> _entries = new BaseCollection<Snapshot>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>A list of basic snapshots information.</summary>
		public BaseCollection<Snapshot> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}