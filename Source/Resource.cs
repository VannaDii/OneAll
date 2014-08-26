using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>Represents a linked resource.</summary>
	[DataContract()]
	public class Resource : BaseObject
	{
		#region Member Variables

		/// <summary>The type.</summary>
		private string _resourceType;

		/// <summary>The value.</summary>
		private string _value;

		#endregion Member Variables

		#region Properties

		#region ResourceType
		/// <summary>The type of URL.</summary>
		[DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
		public string ResourceType
		{
			get { return _resourceType; }
			set { _resourceType = value; OnPropertyChanged("ResourceType"); }
		}
		#endregion ResourceType

		#region Value
		/// <summary>The value.</summary>
		[DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
		public string Value
		{
			get { return _value; }
			set { _value = value; OnPropertyChanged("Value"); }
		}
		#endregion Value

		#endregion Properties
	}
}