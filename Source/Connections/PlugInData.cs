using System.Runtime.Serialization;

namespace OneAll.Connections
{
	/// <summary>Represents the data for the plug-in on a connection.</summary>
	[DataContract(Name = "data")]
	public class PlugInData : BaseObject
	{
		#region Member Variables

		/// <summary>The action.</summary>
		private string _action;

		/// <summary>The operation.</summary>
		private string _operation;

		/// <summary>The reason.</summary>
		private string _reason;

		/// <summary>The status.</summary>
		private string _status;

		#endregion Member Variables

		#region Properties

		#region Action
		/// <summary>The action.</summary>
		[DataMember(Name = "action", IsRequired = false, EmitDefaultValue = false)]
		public string Action
		{
			get { return _action; }
			set { _action = value; OnPropertyChanged("Action"); }
		}
		#endregion Action

		#region Operation
		/// <summary>The operation.</summary>
		[DataMember(Name = "operation", IsRequired = false, EmitDefaultValue = false)]
		public string Operation
		{
			get { return _operation; }
			set { _operation = value; OnPropertyChanged("Operation"); }
		}
		#endregion Operation

		#region Reason
		/// <summary>The reason.</summary>
		[DataMember(Name = "reason", IsRequired = false, EmitDefaultValue = false)]
		public string Reason
		{
			get { return _reason; }
			set { _reason = value; OnPropertyChanged("Reason"); }
		}
		#endregion Reason

		#region Status
		/// <summary>The status.</summary>
		[DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
		public string Status
		{
			get { return _status; }
			set { _status = value; OnPropertyChanged("Status"); }
		}
		#endregion Status

		#endregion Properties
	}
}