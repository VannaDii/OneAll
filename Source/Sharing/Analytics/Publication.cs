using System.Runtime.Serialization;
using OneAll.ShortUrls;
using OneAll.Users;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A publication from an analytics snapshot.</summary>
	[DataContract()]
	public class Publication : PostResultPublication
	{
		#region Member Variables

		/// <summary>A list of associated short URLs.</summary>
		[DataMember(Name = "shorturls", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<SimpleUrl> _shortenedUrls = new BaseCollection<SimpleUrl>();

		#endregion Member Variables

		#region Properties

		#region ShortenedUrls
		/// <summary>A list of associated short URLs.</summary>
		public BaseCollection<SimpleUrl> ShortenedUrls
		{
			get { return _shortenedUrls; }
		}
		#endregion ShortenedUrls

		#endregion Properties
	}
}