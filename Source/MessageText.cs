using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A standard OneAll text part on a user post message.</summary>
	[DataContract()]
	public class MessageText : BaseObject
	{
		#region Member Variables

		/// <summary>The body.</summary>
		private string _body;

		#endregion Member Variables

		#region Properties

		#region Body
		/// <summary>The body.</summary>
		[DataMember(Name = "body", IsRequired = false, EmitDefaultValue = false)]
		public string Body
		{
			get { return _body; }
			set { _body = value; OnPropertyChanged("Body"); }
		}
		#endregion Body

		#endregion Properties
	}
}