using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>The result of a sharing analytics snapshot list request.</summary>
	[DataContract()]
	public class SnapshotListResult : BaseObject
	{
		#region Member Variables

		/// <summary>The snapshot list container.</summary>
		private SnapshotList _snapshots;

		#endregion Member Variables

		#region Properties

		#region Snapshots
		/// <summary>The snapshot list container.</summary>
		[DataMember(Name = "sharing_analytics_snapshots", IsRequired = false, EmitDefaultValue = false)]
		public SnapshotList Snapshots
		{
			get { return _snapshots; }
			set { _snapshots = value; OnPropertyChanged("Snapshots"); }
		}
		#endregion Snapshots

		#endregion Properties
	}
}