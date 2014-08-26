using System;
using System.Runtime.Serialization;

namespace OneAll.Connections
{
	/// <summary>Represents the connection on a connection.</summary>
	[DataContract(Name = "connection")]
	public class Connection : BaseObject
	{
		#region Member Variables

		/// <summary>The connection token.</summary>
		private Guid _connectionToken;

		/// <summary>The connection creation date as an RFC2822 string.</summary>
		[DataMember(Name = "date", IsRequired = false, EmitDefaultValue = false)]
		private string _dateString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		#endregion Member Variables

		#region Properties

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

		#region Date
		/// <summary>The connection creation date.</summary>
		[IgnoreDataMember()]
		public DateTime Date
		{
			get { return (string.IsNullOrEmpty(_dateString) ? DateTime.MinValue : _dateString.DateTimeFromRFC2822()); }
			set
			{
				_dateString = value.DateTimeToRFC2822();
				OnPropertyChanged("Date");
				OnPropertyChanged("DateString");
			}
		}
		#endregion Date

		#endregion Properties
	}
}