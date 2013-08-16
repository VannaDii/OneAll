using System;
using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll contacts result.</summary>
	[DataContract()]
	public class ContactsResultSet : BaseObject
	{
		#region Member Variables

		/// <summary>The last time the cache was updated as an RFC2822 string.</summary>
		[DataMember(Name = "cache_date_last_update", IsRequired = false, EmitDefaultValue = false)]
		private string _cacheDateLastUpdateString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The contacts.</summary>
		[DataMember(Name = "contacts", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<Contact> _contacts = new BaseCollection<Contact>();

		/// <summary>The identity token.</summary>
		private Guid _identityToken = Guid.Empty;

		/// <summary>The provider.</summary>
		private string _provider = string.Empty;

		/// <summary>Indicates if results were read from cache.</summary>
		private bool _readFromCache = false;

		/// <summary>The status.</summary>
		private ContactsResultSetStatus _status = null;

		/// <summary>The user token.</summary>
		private Guid _userToken = Guid.Empty;

		#endregion Member Variables

		#region Properties

		#region Contacts
		/// <summary>The contacts.</summary>
		public BaseCollection<Contact> Contacts
		{
			get { return _contacts; }
		}
		#endregion Contacts

		#region CacheDateLastUpdate
		/// <summary>The last time the cache was updated.</summary>
		[IgnoreDataMember()]
		public DateTime CacheDateLastUpdate
		{
			get { return (string.IsNullOrEmpty(_cacheDateLastUpdateString) ? DateTime.MinValue : _cacheDateLastUpdateString.DateTimeFromRFC2822()); }
			set
			{
				_cacheDateLastUpdateString = value.DateTimeToRFC2822();
				OnPropertyChanged("CacheDateLastUpdate");
			}
		}
		#endregion CacheDateLastUpdate

		#region IdentityToken
		/// <summary>The identity token.</summary>
		[DataMember(Name = "identity_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid IdentityToken
		{
			get { return _identityToken; }
			set
			{
				_identityToken = value;
				OnPropertyChanged("IdentityToken");
			}
		}
		#endregion IdentityToken

		#region Provider
		/// <summary>The provider.</summary>
		[DataMember(Name = "provider", IsRequired = false, EmitDefaultValue = false)]
		public string Provider
		{
			get { return _provider; }
			set
			{
				_provider = value;
				OnPropertyChanged("Provider");
			}
		}
		#endregion Provider

		#region ReadFromCache
		/// <summary>Indicates if results were read from cache.</summary>
		[DataMember(Name = "read_from_cache", IsRequired = false, EmitDefaultValue = false)]
		public bool ReadFromCache
		{
			get { return _readFromCache; }
			set
			{
				_readFromCache = value;
				OnPropertyChanged("ReadFromCache");
			}
		}
		#endregion ReadFromCache

		#region Status
		/// <summary>The status.</summary>
		[DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
		public ContactsResultSetStatus Status
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
			set
			{
				_userToken = value;
				OnPropertyChanged("UserToken");
			}
		}
		#endregion UserToken

		#endregion Properties
	}
}