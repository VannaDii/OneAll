using System;
using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A standard OneAll status object.</summary>
	[DataContract(Name = "shorturl")]
	public class Url : BaseObject
	{
		#region Member Variables

		/// <summary>The original URL to be shortened.</summary>
		private Uri _originalUrl = null;

		#endregion Member Variables

		#region Properties

		#region OriginalUrl
		/// <summary>The original URL to be shortened.</summary>
		[DataMember(Name = "original_url")]
		public Uri OriginalUrl
		{
			get { return _originalUrl; }
			set { _originalUrl = value; OnPropertyChanged("OriginalUrl"); }
		}
		#endregion OriginalUrl

		#endregion Properties
	}
}