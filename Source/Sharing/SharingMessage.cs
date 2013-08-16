using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageResultMessage.</summary>
	[DataContract()]
	public class SharingMessage : BaseObject
	{
		#region Member Variables

		/// <summary>The connection creation date as an RFC2822 string.</summary>
		[DataMember(Name = "date_creation", IsRequired = false, EmitDefaultValue = false)]
		private string _dateCreationString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The publications.</summary>
		private PublicationList _publications;

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

		#region Publications
		/// <summary>The publications.</summary>
		[DataMember(Name = "publications", IsRequired = false, EmitDefaultValue = false)]
		public PublicationList Publications
		{
			get { return _publications; }
			set { _publications = value; OnPropertyChanged("Publications"); }
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