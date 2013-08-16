using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll status on a publication on the message of a user post.</summary>
	[DataContract()]
	public class PostResultPublicationStatus : BaseObject
	{
		#region Member Variables

		/// <summary>The status code.</summary>
		private decimal _code = 0.0M;

		/// <summary>The status flag.</summary>
		private string _indicator = string.Empty;

		/// <summary>The status message.</summary>
		private string _message = string.Empty;

		#endregion Member Variables

		#region Properties

		#region Code
		/// <summary>The status code.</summary>
		[DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
		public decimal Code
		{
			get { return _code; }
			set
			{
				_code = value;
				OnPropertyChanged("Code");
			}
		}
		#endregion Code

		#region Indicator
		/// <summary>The status flag.</summary>
		[DataMember(Name = "flag", IsRequired = false, EmitDefaultValue = false)]
		public string Indicator
		{
			get { return _indicator; }
			set
			{
				_indicator = value;
				OnPropertyChanged("Indicator");
			}
		}
		#endregion Indicator

		#region Message
		/// <summary>The status message.</summary>
		[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
		public string Message
		{
			get { return _message; }
			set
			{
				_message = value;
				OnPropertyChanged("Message");
			}
		}
		#endregion Message

		#endregion Properties
	}
}
