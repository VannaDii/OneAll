using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageRequestMessageUser.</summary>
	[DataContract()]
	public class SharingUser : RequestMessage
	{
		#region Member Variables

		/// <summary>The providers.</summary>
		Collection<string> _providers = new Collection<string>();

		/// <summary>The user token.</summary>
		private Guid _userToken;

		#endregion Member Variables

		#region Properties

		#region Providers
		/// <summary>The providers.</summary>
		[DataMember(Name = "providers", IsRequired = false, EmitDefaultValue = false)]
		public Collection<string> Providers
		{
			get { return _providers; }
		}
		#endregion Providers

		#region UserToken
		/// <summary>The user token.</summary>
		[DataMember(Name = "user_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid UserToken
		{
			get { return _userToken; }
			set { _userToken = value; OnPropertyChanged("UserToken"); }
		}
		#endregion UserToken

		#endregion Properties
	}
}