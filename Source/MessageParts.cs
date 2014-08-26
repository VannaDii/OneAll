using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A standard OneAll parts of a user post message.</summary>
	[DataContract()]
	public class MessageParts : BaseObject
	{
		#region Member Variables

		/// <summary>The link.</summary>
		private MessageLink _link;

		/// <summary>The picture.</summary>
		private MessagePicture _picture;

		/// <summary>The text.</summary>
		private MessageText _text;

		/// <summary>The video.</summary>
		private MessageVideo _video;

		#endregion Member Variables

		#region Properties

		#region Link
		/// <summary>The link.</summary>
		[DataMember(Name = "link", IsRequired = false, EmitDefaultValue = false)]
		public MessageLink Link
		{
			get { return _link; }
			set
			{
				_link = value;
				OnPropertyChanged("Link");
			}
		}
		#endregion Link

		#region Picture
		/// <summary>The picture.</summary>
		[DataMember(Name = "picture", IsRequired = false, EmitDefaultValue = false)]
		public MessagePicture Picture
		{
			get { return _picture; }
			set
			{
				_picture = value;
				OnPropertyChanged("Picture");
			}
		}
		#endregion Picture

		#region Text
		/// <summary>The text.</summary>
		[DataMember(Name = "text", IsRequired = false, EmitDefaultValue = false)]
		public MessageText Text
		{
			get { return _text; }
			set
			{
				_text = value;
				OnPropertyChanged("Text");
			}
		}
		#endregion Text

		#region Video
		/// <summary>The video.</summary>
		[DataMember(Name = "video", IsRequired = false, EmitDefaultValue = false)]
		public MessageVideo Video
		{
			get { return _video; }
			set
			{
				_video = value;
				OnPropertyChanged("Video");
			}
		}
		#endregion Video

		#endregion Properties
	}
}