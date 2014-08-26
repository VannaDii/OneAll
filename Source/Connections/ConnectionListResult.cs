using System.Runtime.Serialization;

namespace OneAll.Connections
{
	/// <summary>The data object for a OneAll connection list.</summary>
	[DataContract(Name = "data")]
	public class ConnectionListResult : BaseObject
	{
		#region Member Variables

		/// <summary>The connections.</summary>
		private ConnectionList _connections = new ConnectionList();

		#endregion Member Variables

		#region Properties

		#region Connections
		/// <summary>The connections.</summary>
		[DataMember(Name = "connections", IsRequired = false, EmitDefaultValue = false)]
		public ConnectionList Connections
		{
			get { return _connections; }
			set
			{
				_connections = value;
				OnPropertyChanged("Connections");
			}
		}
		#endregion Connections

		#endregion Properties
	}
}
