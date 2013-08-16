using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageData.</summary>
	[DataContract()]
	public class SharingResult : BaseObject
	{
		#region Member Variables

		/// <summary>The sharing message.</summary>
		private SharingMessage _sharingMessage;

		#endregion Member Variables

		#region Properties

		#region SharingMessage
		/// <summary>The message.</summary>
		[DataMember(Name = "sharing_message", IsRequired = false, EmitDefaultValue = false)]
		public SharingMessage SharingMessage
		{
			get { return _sharingMessage; }
			set { _sharingMessage = value; OnPropertyChanged("SharingMessage"); }
		}
		#endregion SharingMessage

		#endregion Properties
	}
}