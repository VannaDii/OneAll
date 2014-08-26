using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A request used to initiate a sharing analytics snapshot.</summary>
	[DataContract(Name = "request")]
	public class SnapshotRequest : Request
	{
		#region Member Variables

		/// <summary>The analytics wrapper of the request.</summary>
		private SnapshotAnalytics _analytics = null;

		#endregion Member Variables

		#region Properties

		#region Analytics
		/// <summary>The analytics wrapper of the request.</summary>
		[DataMember(Name = "analytics", IsRequired = false, EmitDefaultValue = false)]
		public SnapshotAnalytics Analytics
		{
			get { return _analytics; }
			set
			{
				_analytics = value;
				OnPropertyChanged("Analytics");
			}
		}
		#endregion Analytics

		#endregion Properties
	}
}