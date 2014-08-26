using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>The details of a shortened URL.</summary>
	[DataContract()]
	public class DetailedUrl : SimpleUrl
	{
		#region Member Variables

		/// <summary>A collection of shortened URL referral entries.</summary>
		private UrlReferralList _referrals = new UrlReferralList();

		#endregion Member Variables

		#region Properties

		#region Referrals
		/// <summary>A collection of shortened URL referral entries.</summary>
		[DataMember(Name = "referrals")]
		public UrlReferralList Referrals
		{
			get { return _referrals; }
			set { _referrals = value; OnPropertyChanged("Referrals"); }
		}
		#endregion Referrals

		#endregion Properties
	}
}