using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A result for a <see cref="Response"/>.</summary>
	/// <typeparam name="TData">The type of the result data.</typeparam>
	[DataContract(Name = "result")]
	public class Result<TData> : BaseObject where TData : BaseObject, new()
	{
		#region Member Variables

		/// <summary>The data of the result.</summary>
		private TData _data = new TData();

		#endregion Member Variables

		#region Properties

		#region Data
		/// <summary>The data of the result.</summary>
		[DataMember(Name = "data", IsRequired = false, EmitDefaultValue = false)]
		public TData Data
		{
			get { return _data; }
			set
			{
				_data = value;
				OnPropertyChanged("Data");
			}
		}
		#endregion Data

		#endregion Properties
	}
}
