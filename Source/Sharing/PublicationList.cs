using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingMessageResultMessagePublications.</summary>
	[DataContract()]
	public class PublicationList : BaseObject
	{
		#region Member Variables

		/// <summary>The entries.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<Publication> _entries = new BaseCollection<Publication>();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The entries.</summary>
		public BaseCollection<Publication> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#endregion Properties
	}
}