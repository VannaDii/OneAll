using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A standard OneAll status object.</summary>
	[DataContract(Name = "status")]
	public class Status : BaseObject
	{
		#region Member Variables

		/// <summary>The status code.</summary>
		private decimal _code = 0.0M;

		/// <summary>The status flag.</summary>
		private string _indicator = string.Empty;

		/// <summary>Additional information about the status.</summary>
		private string _info = string.Empty;

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

		#region Info
		/// <summary>Additional information about the status.</summary>
		[DataMember(Name = "info", IsRequired = false, EmitDefaultValue = false)]
		public string Info
		{
			get { return _info; }
			set
			{
				_info = value;
				OnPropertyChanged("Info");
			}
		}
		#endregion Info

		#endregion Properties
	}
}