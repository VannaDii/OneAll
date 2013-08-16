using System;
using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll user identity.</summary>
	[DataContract(Name = "identity")]
	public class Identity : BaseObject
	{
		#region Member Variables

		/// <summary>The accounts.</summary>
		[DataMember(Name = "accounts", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<AccountEntry> _accounts = new BaseCollection<AccountEntry>();

		/// <summary>The display name.</summary>
		private string _displayName = string.Empty;

		/// <summary>Emails.</summary>
		[DataMember(Name = "emails", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<Email> _emails = new BaseCollection<Email>();

		/// <summary>The id.</summary>
		private string _id = string.Empty;

		/// <summary>The identity token.</summary>
		private Guid _identityToken = Guid.Empty;

		/// <summary>The name.</summary>
		private UserName _name = null;

		/// <summary>The photos.</summary>
		[DataMember(Name = "photos", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<Resource> _photos = new BaseCollection<Resource>();

		/// <summary>The preferred username.</summary>
		private string _preferredUserName = string.Empty;

		/// <summary>The profile URL.</summary>
		private Uri _profileUrl = null;

		/// <summary>The provider.</summary>
		private string _provider = string.Empty;

		/// <summary>The thumbnail URL.</summary>
		private Uri _thumbnailUrl = null;

		/// <summary>The URLS.</summary>
		[DataMember(Name = "urls", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<Resource> _urls = new BaseCollection<Resource>();

		/// <summary>The about me.</summary>
		private string _aboutMe;

		/// <summary>The current location.</summary>
		private string _currentLocation;

		/// <summary>The source.</summary>
		private IdentitySource _source;

		/// <summary>The string value of the UTC offset.</summary>
		[DataMember(Name = "utcOffset", IsRequired = false, EmitDefaultValue = false)]
		private string _utcOffsetString;

		#endregion Member Variables

		#region Properties

		#region AboutMe
		/// <summary>The about me.</summary>
		[DataMember(Name = "aboutMe", IsRequired = false, EmitDefaultValue = false)]
		public string AboutMe
		{
			get { return _aboutMe; }
			set { _aboutMe = value; OnPropertyChanged("AboutMe"); }
		}
		#endregion AboutMe

		#region CurrentLocation
		/// <summary>The current location.</summary>
		[DataMember(Name = "currentLocation", IsRequired = false, EmitDefaultValue = false)]
		public string CurrentLocation
		{
			get { return _currentLocation; }
			set { _currentLocation = value; OnPropertyChanged("CurrentLocation"); }
		}
		#endregion CurrentLocation

		#region Source
		/// <summary>The source.</summary>
		[DataMember(Name = "source", IsRequired = false, EmitDefaultValue = false)]
		public IdentitySource Source
		{
			get { return _source; }
			set { _source = value; OnPropertyChanged("Source"); }
		}
		#endregion Source

		#region UtcOffset
		/// <summary>The UTC offset.</summary>
		[IgnoreDataMember()]
		public TimeSpan UtcOffset
		{
			get { return (string.IsNullOrEmpty(_utcOffsetString) ? TimeSpan.MinValue : _utcOffsetString.ToTimeSpan()); }
			set
			{
				_utcOffsetString = value.ToString();
				OnPropertyChanged("UtcOffset");
			}
		}
		#endregion UtcOffset

		#region Accounts
		/// <summary>The accounts.</summary>
		public BaseCollection<AccountEntry> Accounts
		{
			get { return _accounts; }
		}
		#endregion Accounts

		#region DisplayName
		/// <summary>The display name.</summary>
		[DataMember(Name = "displayName", IsRequired = false, EmitDefaultValue = false)]
		public string DisplayName
		{
			get { return _displayName; }
			set { _displayName = value; OnPropertyChanged("DisplayName"); }
		}
		#endregion DisplayName

		#region Emails
		/// <summary>The emails.</summary>
		public BaseCollection<Email> Emails
		{
			get { return _emails; }
		}
		#endregion Emails

		#region Id
		/// <summary>The id.</summary>
		[DataMember(Name = "id", IsRequired = false, EmitDefaultValue = false)]
		public string Id
		{
			get { return _id; }
			set { _id = value; OnPropertyChanged("Id"); }
		}
		#endregion Id

		#region IdentityToken
		/// <summary>The identity token.</summary>
		[DataMember(Name = "identity_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid IdentityToken
		{
			get { return _identityToken; }
			set { _identityToken = value; OnPropertyChanged("IdentityToken"); }
		}
		#endregion IdentityToken

		#region Name
		/// <summary>The name.</summary>
		[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
		public UserName Name
		{
			get { return _name; }
			set { _name = value; OnPropertyChanged("Name"); }
		}
		#endregion Name

		#region Photos
		/// <summary>The photos.</summary>
		public BaseCollection<Resource> Photos
		{
			get { return _photos; }
		}
		#endregion Photos

		#region PreferredUserName
		/// <summary>The preferred username.</summary>
		[DataMember(Name = "preferredUsername", IsRequired = false, EmitDefaultValue = false)]
		public string PreferredUserName
		{
			get { return _preferredUserName; }
			set { _preferredUserName = value; OnPropertyChanged("PreferredUsername"); }
		}
		#endregion PreferredUserName

		#region ProfileUrl
		/// <summary>The profile url.</summary>
		[DataMember(Name = "profileUrl", IsRequired = false, EmitDefaultValue = false)]
		public Uri ProfileUrl
		{
			get { return _profileUrl; }
			set { _profileUrl = value; OnPropertyChanged("ProfileUrl"); }
		}
		#endregion ProfileUrl

		#region Provider
		/// <summary>The provider.</summary>
		[DataMember(Name = "provider", IsRequired = false, EmitDefaultValue = false)]
		public string Provider
		{
			get { return _provider; }
			set { _provider = value; OnPropertyChanged("Provider"); }
		}
		#endregion Provider

		#region ThumbnailUrl
		/// <summary>The thumbnail url.</summary>
		[DataMember(Name = "thumbnailUrl", IsRequired = false, EmitDefaultValue = false)]
		public Uri ThumbnailUrl
		{
			get { return _thumbnailUrl; }
			set { _thumbnailUrl = value; OnPropertyChanged("ThumbnailUrl"); }
		}
		#endregion ThumbnailUrl

		#region Urls
		/// <summary>The URLs.</summary>
		public BaseCollection<Resource> Urls
		{
			get { return _urls; }
		}
		#endregion Urls

		#endregion Properties
	}
}