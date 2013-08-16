using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageRequestMessageParts.</summary>
	[DataContract()]
	public class SharingMessageParts : MessageParts
	{
		#region Member Variables

		/// <summary>The flags.</summary>
		private TrackingIndicator _indicator = null;

		#endregion Member Variables

		#region Properties

		#region Indicator
		/// <summary>The flags.</summary>
		[DataMember(Name = "flags", IsRequired = false, EmitDefaultValue = false)]
		public TrackingIndicator Indicator
		{
			get { return _indicator; }
			set { _indicator = value; OnPropertyChanged("Indicator"); }
		}
		#endregion Indicator

		#endregion Properties
	}
}