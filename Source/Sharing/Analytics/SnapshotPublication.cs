using System.Runtime.Serialization;

namespace OneAll.Sharing.Analytics
{
	/// <summary>A publication snapshot record.</summary>
	[DataContract()]
	public class SnapshotPublication : BaseObject
	{
		#region Member Variables

		/// <summary>The associated publication.</summary>
		private Publication _publication = null;

		/// <summary>The publication snapshot.</summary>
		private PublicationSnapshot _publicationSnapshot = null;

		#endregion Member Variables

		#region Properties

		#region Publication
		/// <summary>The associated publication.</summary>
		[DataMember(Name = "publication", IsRequired = false, EmitDefaultValue = false)]
		public Publication Publication
		{
			get { return _publication; }
			set { _publication = value; }
		}
		#endregion Publication

		#region PublicationSnapshot
		/// <summary>The publication snapshot.</summary>
		[DataMember(Name = "publication_snapshot", IsRequired = false, EmitDefaultValue = false)]
		public PublicationSnapshot PublicationSnapshot
		{
			get { return _publicationSnapshot; }
			set { _publicationSnapshot = value; }
		}
		#endregion PublicationSnapshot

		#endregion Properties
	}
}