using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A comment reaction from a user to published content.</summary>
	[DataContract()]
	public class UserComment : UserReaction
	{
		#region Member Variables

		/// <summary>The full content of the comment.</summary>
		private string _content = string.Empty;

		/// <summary>The date of the comment.</summary>
		[DataMember(Name = "date", IsRequired = false, EmitDefaultValue = false)]
		private string _dateString = DateTime.MinValue.DateTimeToRFC2822();

		#endregion Member Variables

		#region Properties

		#region Content
		/// <summary>The full content of the comment.</summary>
		[DataMember(Name = "content", IsRequired = false, EmitDefaultValue = false)]
		public string Content
		{
			get { return _content; }
			set { _content = value; OnPropertyChanged("Comment"); }
		}
		#endregion Content

		#region Date
		/// <summary>The date and time the message was last published.</summary>
		[IgnoreDataMember()]
		public DateTime Date
		{
			get { return (string.IsNullOrEmpty(_dateString) ? DateTime.MinValue : _dateString.DateTimeFromRFC2822()); }
			set
			{
				_dateString = value.DateTimeToRFC2822();
				OnPropertyChanged("Date");
			}
		}
		#endregion Date

		#endregion Properties
	}
}