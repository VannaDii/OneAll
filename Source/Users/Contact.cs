using System;
using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll contacts result.</summary>
	[DataContract()]
	public class Contact : BaseObject
	{
		#region Member Variables

		/// <summary>The about me.</summary>
		private string _aboutMe;

		/// <summary>The preferred username.</summary>
		private string _preferredUsername;

		/// <summary>The profile url.</summary>
		private Uri _profileUrl;

		/// <summary>The thumbnail url.</summary>
		private Uri _thumbnailUrl;

		/// <summary>The formatted name.</summary>
		private UserName _name;

		/// <summary>The provider properties.</summary>
		private ProviderProperties _providerProperties;

		#endregion Member Variables

		#region Properties

		#region AboutMe
		/// <summary>The about me.</summary>
		[DataMember(Name = "aboutMe", IsRequired = false, EmitDefaultValue = false)]
		public string AboutMe
		{
			get { return _aboutMe; }
			set
			{
				_aboutMe = value;
				OnPropertyChanged("AboutMe");
			}
		}
		#endregion AboutMe

		#region PreferredUserName
		/// <summary>The preferred username.</summary>
		[DataMember(Name = "preferredUsername", IsRequired = false, EmitDefaultValue = false)]
		public string PreferredUserName
		{
			get { return _preferredUsername; }
			set
			{
				_preferredUsername = value;
				OnPropertyChanged("PreferredUserName");
			}
		}
		#endregion PreferredUserName

		#region ProfileUrl
		/// <summary>The profile url.</summary>
		[DataMember(Name = "profileUrl", IsRequired = false, EmitDefaultValue = false)]
		public Uri ProfileUrl
		{
			get { return _profileUrl; }
			set
			{
				_profileUrl = value;
				OnPropertyChanged("ProfileUrl");
			}
		}
		#endregion ProfileUrl

		#region ThumbnailUrl
		/// <summary>The thumbnail url.</summary>
		[DataMember(Name = "thumbnailUrl", IsRequired = false, EmitDefaultValue = false)]
		public Uri ThumbnailUrl
		{
			get { return _thumbnailUrl; }
			set
			{
				_thumbnailUrl = value;
				OnPropertyChanged("ThumbnailUrl");
			}
		}
		#endregion ThumbnailUrl

		#region ProviderProperties
		/// <summary>The provider properties.</summary>
		[DataMember(Name = "provider_properties", IsRequired = false, EmitDefaultValue = false)]
		public ProviderProperties ProviderProperties
		{
			get { return _providerProperties; }
			set { _providerProperties = value; OnPropertyChanged("ProviderProperties"); }
		}
		#endregion ProviderProperties

		#region Name
		/// <summary>The formatted name.</summary>
		[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
		public UserName Name
		{
			get { return _name; }
			set { _name = value; OnPropertyChanged("Name"); }
		}
		#endregion Name

		#endregion Properties
	}
}