using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A sharing analytics snapshot response.</summary>
	[DataContract()]
	public class Snapshot : BaseObject
	{
		#region Member Variables

		/// <summary>The date and time the analysis was initiated.</summary>
		[DataMember(Name = "date_initiated", IsRequired = false, EmitDefaultValue = false)]
		private string _dateInitiatedString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>The basic information of the associated message.</summary>
		private SnapshotMessage _message = null;

		/// <summary>The unique identifier of the snapshot.</summary>
		private Guid _snapshotToken = Guid.Empty;

		#endregion Member Variables

		#region Properties

		#region DateInitiated
		/// <summary>The date and time the analysis was initiated.</summary>
		[IgnoreDataMember()]
		public DateTime DateInitiated
		{
			get { return (string.IsNullOrEmpty(_dateInitiatedString) ? DateTime.MinValue : _dateInitiatedString.DateTimeFromRFC2822()); }
			set
			{
				_dateInitiatedString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateInitiated");
			}
		}
		#endregion DateInitiated

		#region Message
		/// <summary>The basic information of the associated message.</summary>
		[DataMember(Name = "sharing_message", IsRequired = false, EmitDefaultValue = false)]
		public SnapshotMessage Message
		{
			get { return _message; }
			set
			{
				_message = value;
				OnPropertyChanged("Message");
			}
		}
		#endregion Message

		#region SnapshotToken
		/// <summary>The unique identifier of the snapshot.</summary>
		[DataMember(Name = "sharing_analytics_snapshot_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid SnapshotToken
		{
			get { return _snapshotToken; }
			set
			{
				_snapshotToken = value;
				OnPropertyChanged("SnapshotToken");
			}
		}
		#endregion SnapshotToken

		#endregion Properties
	}
}