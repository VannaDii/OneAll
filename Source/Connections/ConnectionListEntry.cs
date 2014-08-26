using System;
using System.Runtime.Serialization;

namespace OneAll.Connections
{
	/// <summary>A standard OneAll connection list entry.</summary>
	[DataContract(Name = "entry")]
	public class ConnectionListEntry : BaseObject
	{
		#region Member Variables

		/// <summary>The connection callback URI.</summary>
		private Uri _callBackURI;

		/// <summary>The connection token.</summary>
		private Guid _connectionToken;

		/// <summary>The connection creation date as an RFC2822 string.</summary>
		[DataMember(Name = "date_creation", IsRequired = false, EmitDefaultValue = false)]
		private string _dateCreationString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The connection status.</summary>
		private string _status;

		#endregion Member Variables

		#region Properties

		#region CallbackUri
		/// <summary>The callback URI.</summary>
		[DataMember(Name = "callback_uri", IsRequired = false, EmitDefaultValue = false)]
		public Uri CallbackUri
		{
			get { return _callBackURI; }
			set
			{
				_callBackURI = value;
				OnPropertyChanged("CallbackUri");
			}
		}
		#endregion CallbackUri

		#region ConnectionToken
		/// <summary>The connection token.</summary>
		[DataMember(Name = "connection_token", IsRequired = false, EmitDefaultValue = false)]
		public Guid ConnectionToken
		{
			get { return _connectionToken; }
			set
			{
				_connectionToken = value;
				OnPropertyChanged("ConnectionToken");
			}
		}
		#endregion ConnectionToken

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

		#region Status
		/// <summary>The connection status.</summary>
		[DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
		public string Status
		{
			get { return _status; }
			set
			{
				_status = value;
				OnPropertyChanged("Status");
			}
		}
		#endregion Status

		#endregion Properties
	}
}