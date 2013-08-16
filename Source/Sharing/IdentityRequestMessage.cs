using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageRequestMessageIdentity.</summary>
	[DataContract()]
	public class IdentityRequestMessage : BaseObject
	{
		#region Member Variables

		/// <summary>The identity token.</summary>
		private Guid _identityToken;

		#endregion Member Variables

		#region Properties

		#region IdentityToken
		/// <summary>The identity token.</summary>
		[DataMember(Name = "identity_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid IdentityToken
		{
			get { return _identityToken; }
			set { _identityToken = value; OnPropertyChanged("IdentityToken"); }
		}
		#endregion IdentityToken

		#endregion Properties
	}
}