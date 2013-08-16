using System.Runtime.Serialization;

namespace OneAll.Sharing
{
	/// <summary>A standard OneAllSharingListData.</summary>
	[DataContract()]
	public class SharingListResult : BaseObject
	{
		#region Member Variables

		/// <summary>The sharing messages.</summary>
		private SharingList _sharingMessages = new SharingList();

		#endregion Member Variables

		#region Properties

		#region SharingMessages
		/// <summary>The sharing messages.</summary>
		[DataMember(Name = "sharing_messages", IsRequired = false, EmitDefaultValue = false)]
		public SharingList SharingMessages
		{
			get { return _sharingMessages; }
			set { _sharingMessages = value; OnPropertyChanged("SharingMessages"); }
		}
		#endregion SharingMessages

		#endregion Properties
	}
}
