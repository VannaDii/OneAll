using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A standard OneAllSharingMessageRequest.</summary>
	[DataContract(Name = "request")]
	public class UrlRequest : Request
	{
		/// <summary>The shortened URL instance.</summary>
		private Url _shortenedUrl = null;

		/// <summary>The shortened URL instance.</summary>
		[DataMember(Name = "shorturl")]
		public Url ShortenedUrl
		{
			get { return _shortenedUrl; }
			set { _shortenedUrl = value; OnPropertyChanged("ShortenedUrl"); }
		}
	}
}
