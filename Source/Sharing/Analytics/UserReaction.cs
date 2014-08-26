using System;
using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A reaction to published content.</summary>
	[DataContract()]
	public class UserReaction : BaseObject
	{
		#region Member Variables

		/// <summary>The profile URL of the reacting user.</summary>
		private Uri _profileUrl = null;

		/// <summary>The username of the reacting user.</summary>
		private string _userName = string.Empty;

		#endregion Member Variables

		#region Properties

		#region ProfileUrl
		/// <summary>The profile URL of the reacting user.</summary>
		[DataMember(Name = "profileUrl", IsRequired = true, EmitDefaultValue = false)]
		public Uri ProfileUrl
		{
			get { return _profileUrl; }
			set { _profileUrl = value; OnPropertyChanged("ProfileUrl"); }
		}
		#endregion ProfileUrl

		#region UserName
		/// <summary>The username of the reacting user.</summary>
		[DataMember(Name = "username", IsRequired = true, EmitDefaultValue = false)]
		public string UserName
		{
			get { return _userName; }
			set { _userName = value; OnPropertyChanged("UserName"); }
		}
		#endregion UserName

		#endregion Properties
	}
}