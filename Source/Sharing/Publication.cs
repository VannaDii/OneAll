using System.Runtime.Serialization;
using OneAll.ShortUrls;
using OneAll.Users;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageResultMessagePublicationListEntry.</summary>
	[DataContract()]
	public class Publication : PostResultPublication
	{
		#region Member Variables

		/// <summary>The short URLS.</summary>
		private UrlList _shortUrls;

		#endregion Member Variables

		#region Properties

		#region ShortUrls
		/// <summary>The short URLS.</summary>
		[DataMember(Name = "shorturls", IsRequired = false, EmitDefaultValue = false)]
		public UrlList ShortUrls
		{
			get { return _shortUrls; }
			set { _shortUrls = value; OnPropertyChanged("ShortUrls"); }
		}
		#endregion ShortUrls

		#endregion Properties
	}
}