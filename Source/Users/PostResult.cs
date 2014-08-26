using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll data on the result of a user post.</summary>
	[DataContract()]
	public class PostResult : BaseObject
	{
		#region Member Variables

		/// <summary>The message.</summary>
		private PostResultMessage _message;

		#endregion Member Variables

		#region Properties

		#region Message
		/// <summary>The message.</summary>
		[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
		public PostResultMessage Message
		{
			get { return _message; }
			set { _message = value; OnPropertyChanged("Message"); }
		}
		#endregion Message

		#endregion Properties
	}
}