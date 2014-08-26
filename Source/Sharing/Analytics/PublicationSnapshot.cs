using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A snapshot of a publication.</summary>
	[DataContract()]
	public class PublicationSnapshot : BaseObject
	{
		#region Member Variables

		/// <summary>A list of the associated comment reactions.</summary>
		private UserCommentList _comments = null;

		/// <summary>The date and time the snapshot was processed.</summary>
		[DataMember(Name = "date_processed", IsRequired = false, EmitDefaultValue = false)]
		private string _dateProcessedString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>A list of the associated "like" reactions.</summary>
		private UserLikeList _likes = null;

		/// <summary>A list of the associated re-tweet reactions.</summary>
		private UserReTweetList _reTweets = null;

		/// <summary>The status of the publication at the time of the snapshot.</summary>
		private Status _status = null;

		/// <summary>A list of the associated URLs.</summary>
		private SnapshotUrlList _urls = null;

		#endregion Member Variables

		#region Properties

		#region Comments
		/// <summary>A list of the associated comment reactions.</summary>
		[DataMember(Name = "comments", IsRequired = false, EmitDefaultValue = false)]
		public UserCommentList Comments
		{
			get { return _comments; }
			set
			{
				_comments = value;
				OnPropertyChanged("Comments");
			}
		}
		#endregion Comments

		#region DateProcessed
		/// <summary>The date and time the snapshot was processed.</summary>
		[IgnoreDataMember()]
		public DateTime DateProcessed
		{
			get { return (string.IsNullOrEmpty(_dateProcessedString) ? DateTime.MinValue : _dateProcessedString.DateTimeFromRFC2822()); }
			set
			{
				_dateProcessedString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateProcessed");
			}
		}
		#endregion DateProcessed

		#region Likes
		/// <summary>A list of the associated "like" reactions.</summary>
		[DataMember(Name = "likes", IsRequired = false, EmitDefaultValue = false)]
		public UserLikeList Likes
		{
			get { return _likes; }
			set
			{
				_likes = value;
				OnPropertyChanged("Likes");
			}
		}
		#endregion Likes

		#region ReTweets
		/// <summary>A list of the associated re-tweet reactions.</summary>
		[DataMember(Name = "retweets", IsRequired = false, EmitDefaultValue = false)]
		public UserReTweetList ReTweets
		{
			get { return _reTweets; }
			set
			{
				_reTweets = value;
				OnPropertyChanged("ReTweets");
			}
		}
		#endregion ReTweets

		#region Status
		/// <summary>The status of the publication at the time of the snapshot.</summary>
		[DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
		public Status Status
		{
			get { return _status; }
			set
			{
				_status = value;
				OnPropertyChanged("Status");
			}
		}
		#endregion Status

		#region Urls
		/// <summary>A list of the associated URLs.</summary>
		[DataMember(Name = "urls", IsRequired = false, EmitDefaultValue = false)]
		public SnapshotUrlList Urls
		{
			get { return _urls; }
			set
			{
				_urls = value;
				OnPropertyChanged("Urls");
			}
		}
		#endregion Urls

		#endregion Properties
	}
}