using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>The details of a sharing analytics snapshot.</summary>
	[DataContract()]
	public class CompletedSnapshot : Snapshot
	{
		#region Member Variables

		/// <summary>The date and time the analysis was completed.</summary>
		[DataMember(Name = "date_finished", IsRequired = false, EmitDefaultValue = false)]
		private string _dateFinishedString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>A collection of publication details for the snapshot.</summary>
		private SnapshotPublicationList _publicationSnapshots = new SnapshotPublicationList();

		#endregion Member Variables

		#region Properties

		#region DateFinished
		/// <summary>The date and time the analysis was completed.</summary>
		[IgnoreDataMember()]
		public DateTime DateFinished
		{
			get { return (string.IsNullOrEmpty(_dateFinishedString) ? DateTime.MinValue : _dateFinishedString.DateTimeFromRFC2822()); }
			set
			{
				_dateFinishedString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateFinished");
			}
		}
		#endregion DateFinished

		#region PublicationSnapshots
		/// <summary>A collection of publication details for the snapshot.</summary>
		[DataMember(Name = "publication_snapshots", IsRequired = false, EmitDefaultValue = false)]
		public SnapshotPublicationList PublicationSnapshots
		{
			get { return _publicationSnapshots; }
			set { _publicationSnapshots = value; OnPropertyChanged("PublicationSnapshots"); }
		}
		#endregion PublicationSnapshots

		#endregion Properties
	}
}