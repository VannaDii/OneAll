using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A standard OneAllShortenedUrlListData.</summary>
	[DataContract()]
	public class UrlResult : BaseObject
	{
		#region Member Variables

		/// <summary>The shortened URL details.</summary>
		private DetailedUrl _shortenedUrl = null;

		#endregion Member Variables

		#region Properties

		#region ShortenedUrl
		/// <summary>The shortened URL details.</summary>
		[DataMember(Name = "shorturl")]
		public DetailedUrl ShortenedUrl
		{
			get { return _shortenedUrl; }
			set { _shortenedUrl = value; OnPropertyChanged("ShortenedUrl"); }
		}
		#endregion ShortenedUrl

		#endregion Properties
	}
}