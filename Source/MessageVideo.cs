using System;
using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A standard OneAll video part on a user post message.</summary>
	[DataContract()]
	public class MessageVideo : BaseObject
	{
		#region Member Variables

		/// <summary>The url.</summary>
		private Uri _url;

		#endregion Member Variables

		#region Properties

		#region Url
		/// <summary>The url.</summary>
		[DataMember(Name = "url", IsRequired = false, EmitDefaultValue = false)]
		public Uri Url
		{
			get { return _url; }
			set { _url = value; OnPropertyChanged("Url"); }
		}
		#endregion Url

		#endregion Properties
	}
}