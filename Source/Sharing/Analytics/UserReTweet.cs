using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A re-tweet reaction from a user to published content.</summary>
	[DataContract()]
	public class UserReTweet : UserReaction
	{
		#region Member Variables

		/// <summary>The date the re-tweeting user became a member.</summary>
		[DataMember(Name = "date_member_since", IsRequired = false, EmitDefaultValue = false)]
		private string _dateMemberSinceString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>The number of followers to whom the published content was re-tweeted.</summary>
		private long _followerCount = 0L;

		#endregion Member Variables

		#region Properties

		#region DateMemberSince
		/// <summary>The date the re-tweeting user became a member.</summary>
		[IgnoreDataMember()]
		public DateTime DateMemberSince
		{
			get { return (string.IsNullOrEmpty(_dateMemberSinceString) ? DateTime.MinValue : _dateMemberSinceString.DateTimeFromRFC2822()); }
			set
			{
				_dateMemberSinceString = value.DateTimeToRFC2822();
				OnPropertyChanged("DateMemberSince");
			}
		}
		#endregion DateMemberSince

		#region FollowerCount
		/// <summary>The number of followers to whom the published content was re-tweeted.</summary>
		[DataMember(Name = "num_followers", IsRequired = false, EmitDefaultValue = false)]
		public long FollowerCount
		{
			get { return _followerCount; }
			set { _followerCount = value; OnPropertyChanged("FollowerCount"); }
		}
		#endregion FollowerCount

		#endregion Properties
	}
}