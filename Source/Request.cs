using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A standard OneAll request object.</summary>
	[DataContract(Name = "request")]
	public class Request : BaseObject
	{
		#region Member Variables

		/// <summary>The request date and time as an RFC2822 string.</summary>
		[DataMember(Name = "date", IsRequired = false, EmitDefaultValue = false), DefaultValue("")]
		private string _dateString = DateTime.MinValue.ToUniversalTime().DateTimeToRFC2822();

		/// <summary>The resource requested.</summary>
		private string _resource = string.Empty;

		/// <summary>The status information.</summary>
		private Status _status = null;

		#endregion Member Variables

		#region Properties

		#region Date
		/// <summary>The request date and time</summary>
		[IgnoreDataMember()]
		public DateTime Date
		{
			get { return (string.IsNullOrEmpty(_dateString) ? DateTime.MinValue : _dateString.DateTimeFromRFC2822()); }
			set
			{
				_dateString = value.DateTimeToRFC2822();
				OnPropertyChanged("Date");
			}
		}
		#endregion Date

		#region Resource
		/// <summary>The resource requested.</summary>
		[DataMember(Name = "resource", IsRequired = false, EmitDefaultValue = false), DefaultValue("")]
		public string Resource
		{
			get { return _resource; }
			set
			{
				_resource = value;
				OnPropertyChanged("Resource");
			}
		}
		#endregion Resource

		#region Status
		/// <summary>The status information.</summary>
		[DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false), DefaultValue(null)]
		public Status Status
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