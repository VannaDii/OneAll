using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A collection of referral entries.</summary>
	[DataContract()]
	public class UrlReferralList : BaseObject
	{
		#region Member Variables

		/// <summary>A collection of shortened URL referrals.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<UrlReferral> _entries = new BaseCollection<UrlReferral>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>A collection of shortened URL referrals.</summary>
		public BaseCollection<UrlReferral> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}
