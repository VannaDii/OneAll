using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>Describes the pagination of items.</summary>
	[DataContract(Name = "pagination")]
	public class Pagination : BaseObject
	{
		#region Member Variables

		/// <summary>The current 1-based page number.</summary>
		private int _currentPage = 1;

		/// <summary>The ordering details for the items.</summary>
		private Order _order = new Order();

		/// <summary>The number of items per page.</summary>
		private int _perPage = 0;

		/// <summary>The total number of entries available.</summary>
		private long _totalEntries = 0;

		/// <summary>The total number of pages available.</summary>
		private int _totalPages = 0;

		#endregion Member Variables

		#region Properties

		#region CurrentPage
		/// <summary>The current 1-based page number.</summary>
		[DataMember(Name = "current_page", IsRequired = false, EmitDefaultValue = false)]
		public int CurrentPage
		{
			get { return _currentPage; }
			set
			{
				_currentPage = value;
				OnPropertyChanged("CurrentPage");
			}
		}
		#endregion CurrentPage

		#region Order
		/// <summary>The ordering details for the items.</summary>
		[DataMember(Name = "order", IsRequired = false, EmitDefaultValue = false)]
		public Order Order
		{
			get { return _order; }
			set
			{
				_order = value;
				OnPropertyChanged("Order");
			}
		}
		#endregion Order

		#region PerPage
		/// <summary>The number of items per page.</summary>
		[DataMember(Name = "entries_per_page", IsRequired = false, EmitDefaultValue = false)]
		public int PerPage
		{
			get { return _perPage; }
			set
			{
				_perPage = value;
				OnPropertyChanged("PerPage");
			}
		}
		#endregion PerPage

		#region TotalEntries
		/// <summary>The total number of entries available.</summary>
		[DataMember(Name = "count_total_entries", IsRequired = false, EmitDefaultValue = false)]
		public long TotalEntries
		{
			get { return _totalEntries; }
			set
			{
				_totalEntries = value;
				OnPropertyChanged("TotalEntries");
			}
		}
		#endregion TotalEntries

		#region TotalPages
		/// <summary>The total number of pages available.</summary>
		[DataMember(Name = "count_total_pages", IsRequired = false, EmitDefaultValue = false)]
		public int TotalPages
		{
			get { return _totalPages; }
			set
			{
				_totalPages = value;
				OnPropertyChanged("TotalPages");
			}
		}
		#endregion TotalPages

		#endregion Properties
	}
}