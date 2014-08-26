using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>The sharing node of a snapshot initiation request.</summary>
	[DataContract()]
	public class SnapshotAnalyticsDetail : BaseObject
	{
		#region Member Variables

		/// <summary>The unique identifier of a message to analyze.</summary>
		private Guid _messageToken = Guid.Empty;

		/// <summary>The URL to be called by the OneAll server for notifications regarding this request.</summary>
		private Uri _pingbackUri = null;

		#endregion Member Variables

		#region Properties

		#region MessageToken
		/// <summary>The unique identifier of a message to analyze.</summary>
		[DataMember(Name = "sharing_message_token", IsRequired = true, EmitDefaultValue = false)]
		public Guid MessageToken
		{
			get { return _messageToken; }
			set
			{
				_messageToken = value;
				OnPropertyChanged("MessageToken");
			}
		}
		#endregion MessageToken

		#region PingBackUri
		/// <summary>The URL to be called by the OneAll server for notifications regarding this request.</summary>
		[DataMember(Name = "pingback_uri", IsRequired = false, EmitDefaultValue = false), DefaultValue(null)]
		public Uri PingbackUri
		{
			get { return _pingbackUri; }
			set
			{
				_pingbackUri = value;
				OnPropertyChanged("PingBackUri");
			}
		}
		#endregion PingBackUri

		#endregion Properties
	}
}