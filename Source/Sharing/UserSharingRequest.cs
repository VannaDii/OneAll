using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageRequestMessage.</summary>
	[DataContract()]
	public class UserSharingRequest : RequestMessage
	{
		#region Member Variables

		/// <summary>The parts.</summary>
		private SharingMessageParts _parts = null;

		/// <summary>The user to publish for.</summary>
		private SharingUser _publishForUser = null;

		#endregion Member Variables

		#region Properties

		#region Parts
		/// <summary>The parts.</summary>
		[DataMember(Name = "parts", IsRequired = false, EmitDefaultValue = false)]
		public SharingMessageParts Parts
		{
			get { return _parts; }
			set { _parts = value; OnPropertyChanged("Parts"); }
		}
		#endregion Parts

		#region PublishForUser
		/// <summary>The publish for user.</summary>
		[DataMember(Name = "publish_for_user", IsRequired = false, EmitDefaultValue = false)]
		public SharingUser PublishForUser
		{
			get { return _publishForUser; }
			set { _publishForUser = value; OnPropertyChanged("PublishForUser"); }
		}
		#endregion PublishForUser

		#endregion Properties
	}
}