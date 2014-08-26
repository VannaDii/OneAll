using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A URL from an analytics snapshot.</summary>
	[DataContract()]
	public class SnapshotUrl : BaseObject
	{
		#region Member Variables

		/// <summary>The number of referrals.</summary>
		private long _referralCount = 0L;

		/// <summary>The target URL.</summary>
		private Uri _targetUrl = null;

		#endregion Member Variables

		#region Properties

		#region ReferralCount
		/// <summary>The number of referrals.</summary>
		[DataMember(Name = "num_referrals", IsRequired = false, EmitDefaultValue = false)]
		public long ReferralCount
		{
			get { return _referralCount; }
			set { _referralCount = value; OnPropertyChanged("ReferralCount"); }
		}
		#endregion ReferralCount

		#region TargetUrl
		/// <summary>The target URL.</summary>
		[DataMember(Name = "target", IsRequired = false, EmitDefaultValue = false)]
		public Uri TargetUrl
		{
			get { return _targetUrl; }
			set { _targetUrl = value; OnPropertyChanged("TargetUrl"); }
		}
		#endregion TargetUrl

		#endregion Properties
	}
}