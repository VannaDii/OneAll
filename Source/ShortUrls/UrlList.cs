using System.Runtime.Serialization;

namespace OneAll.ShortUrls
{
	/// <summary>A list of OneAll shortened URLs.</summary>
	[DataContract()]
	public class UrlList : BaseObject
	{
		#region Member Variables

		/// <summary>A collection of shortened URL entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<SimpleUrl> _entries = new BaseCollection<SimpleUrl>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>A collection of shortened URL entries.</summary>
		public BaseCollection<SimpleUrl> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}