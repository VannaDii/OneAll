using System;
using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A standard OneAll link part on a user post message.</summary>
	[DataContract()]
	public class MessageLink : BaseObject
	{
		#region Member Variables

		/// <summary>The caption.</summary>
		private string _caption;

		/// <summary>The description.</summary>
		private string _description;

		/// <summary>The name.</summary>
		private string _name;

		/// <summary>The url.</summary>
		private Uri _url;

		#endregion Member Variables

		#region Properties

		#region Caption
		/// <summary>The caption.</summary>
		[DataMember(Name = "caption", IsRequired = false, EmitDefaultValue = false)]
		public string Caption
		{
			get { return _caption; }
			set { _caption = value; OnPropertyChanged("Caption"); }
		}
		#endregion Caption

		#region Description
		/// <summary>The description.</summary>
		[DataMember(Name = "description", IsRequired = false, EmitDefaultValue = false)]
		public string Description
		{
			get { return _description; }
			set { _description = value; OnPropertyChanged("Description"); }
		}
		#endregion Description

		#region Name
		/// <summary>The name.</summary>
		[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
		public string Name
		{
			get { return _name; }
			set { _name = value; OnPropertyChanged("Name"); }
		}
		#endregion Name

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