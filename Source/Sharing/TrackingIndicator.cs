using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard <see cref="TrackingIndicator"/>.</summary>
	[DataContract()]
	public class TrackingIndicator : BaseObject
	{
		#region Member Variables

		/// <summary>Indicates if tracking is enabled.</summary>
		private bool _enableTracking = false;

		#endregion Member Variables

		#region Properties

		#region EnableTracking
		/// <summary>Indicates if tracking is enabled.</summary>
		[DataMember(Name = "enable_tracking", IsRequired = false, EmitDefaultValue = false)]
		public bool EnableTracking
		{
			get { return _enableTracking; }
			set { _enableTracking = value; OnPropertyChanged("EnableTracking"); }
		}
		#endregion EnableTracking

		#endregion Properties
	}
}