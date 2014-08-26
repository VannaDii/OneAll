using System;
using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll publication on the message of a user post.</summary>
	[DataContract()]
	public class PostResultPublication : BaseObject
	{
		#region Member Variables

		/// <summary>The publication date as an RFC2822 string.</summary>
		[DataMember(Name = "date_publication", IsRequired = false, EmitDefaultValue = false)]
		private string _datePublicationString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The identity token.</summary>
		private Guid _identityToken;

		/// <summary>The provider.</summary>
		private string _provider;

		/// <summary>The status information.</summary>
		private PostResultPublicationStatus _status;

		/// <summary>The user token.</summary>
		private Guid _userToken;

		#endregion Member Variables

		#region Properties

		#region DatePublication
		/// <summary>The publication date.</summary>
		[IgnoreDataMember()]
		public DateTime DatePublication
		{
			get { return (string.IsNullOrEmpty(_datePublicationString) ? DateTime.MinValue : _datePublicationString.DateTimeFromRFC2822()); }
			set
			{
				_datePublicationString = value.DateTimeToRFC2822();
				OnPropertyChanged("DatePublication");
			}
		}
		#endregion DatePublication

		#region IdentityToken
		/// <summary>The identity token.</summary>
		[DataMember(Name = "identity_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid IdentityToken
		{
			get { return _identityToken; }
			set { _identityToken = value; OnPropertyChanged("IdentityToken"); }
		}
		#endregion IdentityToken

		#region Provider
		/// <summary>The provider.</summary>
		[DataMember(Name = "provider", IsRequired = false, EmitDefaultValue = false)]
		public string Provider
		{
			get { return _provider; }
			set { _provider = value; OnPropertyChanged("Provider"); }
		}
		#endregion Provider

		#region Status
		/// <summary>The status information.</summary>
		[DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
		public PostResultPublicationStatus Status
		{
			get { return _status; }
			set
			{
				_status = value;
				OnPropertyChanged("Status");
			}
		}
		#endregion Status

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