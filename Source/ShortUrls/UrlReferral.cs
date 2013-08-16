using System;
using System.Net;
using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A referral entry for a shortened URL.</summary>
	[DataContract()]
	public class UrlReferral : BaseObject
	{
		#region Member Variables

		/// <summary>The creation date string value.</summary>
		[DataMember(Name = "date_creation", IsRequired = false, EmitDefaultValue = false)]
		private string _dateCreationString = DateTime.MinValue.DateTimeToRFC2822();

		/// <summary>The IP address of the referral in string value.</summary>
		[DataMember(Name = "ip_address", IsRequired = false, EmitDefaultValue = false)]
		private string _ipAddressString = IPAddress.None.ToString();

		/// <summary>The page of the referral.</summary>
		private string _page = string.Empty;

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

		#region IPAddress
		/// <summary>The IP address of the referral.</summary>
		public IPAddress IPAddress
		{
			get
			{
				IPAddress retVal = IPAddress.None;
				return (IPAddress.TryParse(_ipAddressString, out retVal) ? retVal : IPAddress.None);
			}
			set
			{
				_ipAddressString = (value != null ? value : IPAddress.None).ToString();
				OnPropertyChanged("IPAddress");
			}
		}
		#endregion IPAddress

		#region Page
		/// <summary>The page of the referral.</summary>
		[DataMember(Name = "page", IsRequired = false, EmitDefaultValue = false)]
		public string Page
		{
			get { return _page; }
			set { _page = value; OnPropertyChanged("Page"); }
		}
		#endregion Page

		#endregion Properties
	}
}