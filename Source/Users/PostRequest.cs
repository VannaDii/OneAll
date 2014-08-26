using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll user message request.</summary>
	[DataContract(Name = "request")]
	public class PostRequest : Request
	{
		#region Member Variables

		/// <summary>The message.</summary>
		private PostMessage _message;

		#endregion Member Variables

		#region Properties

		#region Message
		/// <summary>The message.</summary>
		[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
		public PostMessage Message
		{
			get { return _message; }
			set { _message = value; OnPropertyChanged("Message"); }
		}
		#endregion Message

		#endregion Properties
	}
}