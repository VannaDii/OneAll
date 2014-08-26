using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A message from a sharing analytics snapshot response.</summary>
	[DataContract()]
	public class SnapshotMessage : BaseObject
	{
		#region Member Variables

		/// <summary>The data and time the message was created.</summary>
		[DataMember(Name = "date_creation", IsRequired = false, EmitDefaultValue = false)]
		private string _dateCreationString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>The date and time the message was last published.</summary>
		[DataMember(Name = "date_last_published", IsRequired = false, EmitDefaultValue = false)]
		private string _dateLastPublishedString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>The unique identifier for the message.</summary>
		private Guid _messageToken = Guid.Empty;

		#endregion Member Variables

		#region Properties

		#region DateCreated
		/// <summary>The data and time the message was created.</summary>
		[IgnoreDataMember()]
		public DateTime DateCreated
		{
			get { return (string.IsNullOrEmpty(_dateCreationString) ? DateTime.MinValue : _dateCreationString.DateTimeFromRFC2822()); }
			set
			{
				_dateCreationString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateCreated");
			}
		}
		#endregion DateCreated

		#region DateLastPublished
		/// <summary>The date and time the message was last published.</summary>
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

		#region MessageToken
		/// <summary>The unique identifier for the message.</summary>
		[DataMember(Name = "sharing_message_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid MessageToken
		{
			get { return _messageToken; }
			set
			{
				_messageToken = value;
				OnPropertyChanged("MessageToken");
			}
		}
		#endregion MessageToken

		#endregion Properties
	}
}