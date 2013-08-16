using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll contacts result data.</summary>
	[DataContract()]
	public class ContactsResult : BaseObject
	{
		#region Member Variables

		/// <summary>The action.</summary>
		private string _action;

		/// <summary>The results.</summary>
		[DataMember(Name = "results", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<ContactsResultSet> _results = new BaseCollection<ContactsResultSet>();

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

		#region Results
		/// <summary>The results.</summary>
		public BaseCollection<ContactsResultSet> Results
		{
			get { return _results; }
		}
		#endregion Results

		#endregion Properties
	}
}