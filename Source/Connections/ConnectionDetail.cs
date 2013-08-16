using System.Runtime.Serialization;

namespace OneAll.Connections
{
	/// <summary>Represents a connection.</summary>
	[DataContract()]
	public class ConnectionDetail : BaseObject
	{
		#region Member Variables

		/// <summary>The action.</summary>
		private string _action;

		/// <summary>The connection.</summary>
		private Connection _connection;

		/// <summary>The plug-in.</summary>
		private PlugIn _plugin;

		/// <summary>The user.</summary>
		private ConnectionUser _user;

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

		#region Connection
		/// <summary>The connection.</summary>
		[DataMember(Name = "connection", IsRequired = false, EmitDefaultValue = false)]
		public Connection Connection
		{
			get { return _connection; }
			set { _connection = value; OnPropertyChanged("Connection"); }
		}
		#endregion Connection

		#region PlugIn
		/// <summary>The PlugIn.</summary>
		[DataMember(Name = "plugin", IsRequired = false, EmitDefaultValue = false)]
		public PlugIn PlugIn
		{
			get { return _plugin; }
			set { _plugin = value; OnPropertyChanged("PlugIn"); }
		}
		#endregion PlugIn

		#region User
		/// <summary>The user.</summary>
		[DataMember(Name = "user", IsRequired = false, EmitDefaultValue = false)]
		public ConnectionUser User
		{
			get { return _user; }
			set { _user = value; OnPropertyChanged("User"); }
		}
		#endregion User

		#endregion Properties
	}
}