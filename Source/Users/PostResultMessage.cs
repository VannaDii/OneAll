using System;
using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll message on the data in the result of a user post.</summary>
	[DataContract()]
	public class PostResultMessage : BaseObject
	{
		#region Member Variables

		/// <summary>The connection creation date as an RFC2822 string.</summary>
		[DataMember(Name = "date_creation", IsRequired = false, EmitDefaultValue = false)]
		private string _dateCreationString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The last published date as an RFC2822 string.</summary>
		[DataMember(Name = "date_last_published", IsRequired = false, EmitDefaultValue = false)]
		private string _dateLastPublishedString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The publications.</summary>
		[DataMember(Name = "publications", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<PostResultPublication> _publications = new BaseCollection<PostResultPublication>();

		/// <summary>The sharing message token.</summary>
		private Guid _sharingMessageToken;

		#endregion Member Variables

		#region Properties

		#region DateCreation
		/// <summary>The connection creation date.</summary>
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

		#region DateLastPublished
		/// <summary>The last published date.</summary>
		[IgnoreDataMember()]
		public DateTime DateLastPublished
		{
			get { return (string.IsNullOrEmpty(_dateLastPublishedString) ? DateTime.MinValue : _dateLastPublishedString.DateTimeFromRFC2822()); }
			set
			{
				_dateLastPublishedString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateLastPublished");
			}
		}
		#endregion DateLastPublished

		#region Publications
		/// <summary>The publications.</summary>
		public BaseCollection<PostResultPublication> Publications
		{
			get { return _publications; }
		}
		#endregion Publications

		#region SharingMessageToken
		/// <summary>The sharing message token.</summary>
		[DataMember(Name = "sharing_message_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid SharingMessageToken
		{
			get { return _sharingMessageToken; }
			set { _sharingMessageToken = value; OnPropertyChanged("SharingMessageToken"); }
		}
		#endregion SharingMessageToken

		#endregion Properties
	}
}