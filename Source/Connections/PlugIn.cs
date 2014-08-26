using System.Runtime.Serialization;

namespace OneAll.Connections
{
	/// <summary>Represents the plug-in on a connection.</summary>
	[DataContract(Name = "plugin")]
	public class PlugIn : BaseObject
	{
		#region Member Variables

		/// <summary>The data.</summary>
		private PlugInData _data;

		/// <summary>The key.</summary>
		private string _key;

		#endregion Member Variables

		#region Properties

		#region Data
		/// <summary>The data.</summary>
		[DataMember(Name = "data", IsRequired = false, EmitDefaultValue = false)]
		public PlugInData Data
		{
			get { return _data; }
			set { _data = value; OnPropertyChanged("Data"); }
		}
		#endregion Data

		#region Key
		/// <summary>The key.</summary>
		[DataMember(Name = "key", IsRequired = false, EmitDefaultValue = false)]
		public string Key
		{
			get { return _key; }
			set { _key = value; OnPropertyChanged("Key"); }
		}
		#endregion Key

		#endregion Properties
	}
}