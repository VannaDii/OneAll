using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A standard OneAllSharingMessageData.</summary>
	[DataContract()]
	public class UrlListResult : BaseObject
	{
		#region Member Variables

		/// <summary>The shortened URL list.</summary>
		private UrlList _shortenedUrls = new UrlList();

		#endregion Member Variables

		#region Properties

		#region ShortenedUrls
		/// <summary>The shortened URL list.</summary>
		[DataMember(Name = "shorturls")]
		public UrlList ShortenedUrls
		{
			get { return _shortenedUrls; }
			set { _shortenedUrls = value; OnPropertyChanged("ShortenedUrls"); }
		}
		#endregion ShortenedUrls

		#endregion Properties
	}
}