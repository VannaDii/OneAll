using System.Runtime.Serialization;

namespace OneAll.Connections
{
	/// <summary>A standard OneAll connection list.</summary>
	[DataContract(Name = "connections")]
	public class ConnectionList : BaseObject
	{
		#region Member Variables

		/// <summary>The entries in the list.</summary>
		[DataMember(Name = "entries", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<ConnectionListEntry> _entries = new BaseCollection<ConnectionListEntry>();

		/// <summary>Indicates if the list has pagination data.</summary>
		private bool _paginated = false;

		/// <summary>The data pagination description.</summary>
		private Pagination _pagination = new Pagination();

		#endregion Member Variables

		#region Properties

		#region Entries
		/// <summary>The entries in the list.</summary>
		public BaseCollection<ConnectionListEntry> Entries
		{
			get { return _entries; }
		}
		#endregion Entries

		#region Paginated
		/// <summary>Indicates if the list has pagination data.</summary>
		[DataMember(Name = "paginated", IsRequired = false, EmitDefaultValue = false)]
		public bool Paginated
		{
			get { return _paginated; }
			set
			{
				_paginated = value;
				OnPropertyChanged("Paginated");
			}
		}
		#endregion Paginated

		#region Pagination
		/// <summary>The data pagination description.</summary>
		[DataMember(Name = "pagination", IsRequired = false, EmitDefaultValue = false)]
		public Pagination Pagination
		{
			get { return _pagination; }
			set
			{
				_pagination = value;
				OnPropertyChanged("Pagination");
			}
		}
		#endregion Pagination

		#endregion Properties
	}
}