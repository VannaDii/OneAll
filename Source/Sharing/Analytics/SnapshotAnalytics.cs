using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>The analytics node of a snapshot initiation request.</summary>
	[DataContract()]
	public class SnapshotAnalytics : BaseObject
	{
		#region Member Variables

		/// <summary>The sharing wrapper of a snapshot initiation request.</summary>
		private SnapshotAnalyticsDetail _sharing = null;

		#endregion Member Variables

		#region Properties

		#region Sharing
		/// <summary>The sharing wrapper of a snapshot initiation request.</summary>
		[DataMember(Name = "sharing", IsRequired = false, EmitDefaultValue = false)]
		public SnapshotAnalyticsDetail Sharing
		{
			get { return _sharing; }
			set
			{
				_sharing = value;
				OnPropertyChanged("Sharing");
			}
		}
		#endregion Sharing

		#endregion Properties
	}
}