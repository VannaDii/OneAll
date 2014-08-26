using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageRequestMessage.</summary>
	[DataContract()]
	public class IdentityRequest : RequestMessage
	{
		#region Member Variables

		/// <summary>The parts.</summary>
		private SharingMessageParts _parts;

		/// <summary>The identity to publish for.</summary>
		private IdentityRequestMessage _publishForIdentity;

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

		#region PublishForIdentity
		/// <summary>The identity to publish for.</summary>
		[DataMember(Name = "publish_for_identity", IsRequired = false, EmitDefaultValue = false)]
		public IdentityRequestMessage PublishForIdentity
		{
			get { return _publishForIdentity; }
			set { _publishForIdentity = value; OnPropertyChanged("PublishForIdentity"); }
		}
		#endregion PublishForIdentity

		#endregion Properties
	}
}