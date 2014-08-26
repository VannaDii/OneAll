using System;
using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll user.</summary>
	[DataContract(Name = "user")]
	public class User : BaseObject
	{
		#region Member Variables

		/// <summary>The connection creation date as an RFC2822 string.</summary>
		[DataMember(Name = "date_creation", IsRequired = false, EmitDefaultValue = false)]
		private string _dateCreationString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The user last login date as an RFC2822 string.</summary>
		[DataMember(Name = "date_last_login", IsRequired = false, EmitDefaultValue = false)]
		private string _dateLastLoginString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The number of logins.</summary>
		private long _logOnCount = 0;

		/// <summary>The user token.</summary>
		private Guid _userToken = Guid.Empty;

		/// <summary>The user identities.</summary>
		private IdentityList _identities = new IdentityList();

		#endregion Member Variables

		#region Properties

		#region DateCreation
		/// <summary>The user creation date.</summary>
		[IgnoreDataMember()]
		public DateTime DateCreation
		{
			get { return (string.IsNullOrEmpty(_dateCreationString) ? DateTime.MinValue : _dateCreationString.DateTimeFromRFC2822()); }
			set
			{
				_dateCreationString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateCreation");
			}
		}
		#endregion DateCreation

		#region DateLastLogOn
		/// <summary>The user last login date.</summary>
		[IgnoreDataMember()]
		public DateTime DateLastLogOn
		{
			get { return (string.IsNullOrEmpty(_dateLastLoginString) ? DateTime.MinValue : _dateLastLoginString.DateTimeFromRFC2822()); }
			set
			{
				_dateLastLoginString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateLastLogOn");
			}
		}
		#endregion DateLastLogOn

		#region LogOnCount
		/// <summary>The number of logins.</summary>
		[DataMember(Name = "num_logins", IsRequired = false, EmitDefaultValue = false)]
		public long LogOnCount
		{
			get { return _logOnCount; }
			set { _logOnCount = value; OnPropertyChanged("LogOnCount"); }
		}
		#endregion LogOnCount

		#region UserToken
		/// <summary>The user token.</summary>
		[DataMember(Name = "user_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid UserToken
		{
			get { return _userToken; }
			set { _userToken = value; OnPropertyChanged("UserToken"); }
		}
		#endregion UserToken

		#region Identities
		/// <summary>The user identities.</summary>
		[DataMember(Name = "identities", IsRequired = false, EmitDefaultValue = false)]
		public IdentityList Identities
		{
			get { return _identities; }
			set { _identities = value; OnPropertyChanged("Identities"); }
		}
		#endregion Identities

		#endregion Properties
	}
}
