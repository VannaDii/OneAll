using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageRequest.</summary>
	[DataContract(Name = "request")]
	public class SharingRequest<T> : Request where T : RequestMessage
	{
		#region Member Variables

		/// <summary>The sharing message.</summary>
		private T _sharingMessage;

		#endregion Member Variables

		#region Properties

		#region SharingMessage
		/// <summary>The sharing message.</summary>
		[DataMember(Name = "sharing_message", IsRequired = false, EmitDefaultValue = false)]
		public T SharingMessage
		{
			get { return _sharingMessage; }
			set
			{
				_sharingMessage = value;
				OnPropertyChanged("SharingMessage");
			}
		}
		#endregion SharingMessage

		#endregion Properties
	}
}