using System;
using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A shortened URL entry.</summary>
	[DataContract()]
	public class SimpleUrl : Url
	{
		#region Member Variables

		/// <summary>The creation date string value.</summary>
		[DataMember(Name = "date_creation", IsRequired = false, EmitDefaultValue = false)]
		private string _dateCreationString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>The date of the last referral string value.</summary>
		[DataMember(Name = "date_last_referral", IsRequired = false, EmitDefaultValue = false)]
		private string _dateLastReferralString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>The number of referrals.</summary>
		private long _referralCount = 0L;

		/// <summary>The shortened URL.</summary>
		private Uri _shortenedUrl = null;

		/// <summary>The shortened URL token.</summary>
		private string _token = string.Empty;

		#endregion Member Variables

		#region Properties

		#region DateCreation
		/// <summary>The creation date.</summary>
		public DateTime DateCreation
		{
			get { return (string.IsNullOrEmpty(_dateCreationString) ? DateTime.MinValue : _dateCreationString.DateTimeFromRFC2822()); }
			set
			{
				_dateCreationString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateCreation");
			}
		}
		#endregion DateCreation

		#region DateLastReferral
		/// <summary>The date of the last referral.</summary>
		public DateTime DateLastReferral
		{
			get { return (string.IsNullOrEmpty(_dateLastReferralString) ? DateTime.MinValue : _dateLastReferralString.DateTimeFromRFC2822()); }
			set
			{
				_dateLastReferralString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateLastReferral");
			}
		}
		#endregion DateLastReferral

		#region ReferralCount
		/// <summary>The number of referrals.</summary>
		[DataMember(Name = "num_referrals")]
		public long ReferralCount
		{
			get { return _referralCount; }
			set { _referralCount = value; OnPropertyChanged("ReferralCount"); }
		}
		#endregion ReferralCount

		#region ShortenedUrl
		/// <summary>The shortened URL.</summary>
		[DataMember(Name = "short_url")]
		public Uri ShortenedUrl
		{
			get { return _shortenedUrl; }
			set { _shortenedUrl = value; OnPropertyChanged("ShortenedUrl"); }
		}
		#endregion ShortenedUrl

		#region Token
		/// <summary>The shortened URL token.</summary>
		[DataMember(Name = "shorturl_token")]
		public string Token
		{
			get { return _token; }
			set { _token = value; OnPropertyChanged("Token"); }
		}
		#endregion Token

		#endregion Properties
	}
}