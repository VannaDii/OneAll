using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A standard OneAll response.</summary>
	[DataContract(Name = "response")]
	public class Response : BaseObject
	{
		#region Member Variables

		/// <summary>The request of the response.</summary>
		private Request _request = new Request();

		#endregion Member Variables

		#region Properties

		#region Request
		/// <summary>The request of the response.</summary>
		[DataMember(Name = "request", IsRequired = false, EmitDefaultValue = false)]
		public Request Request
		{
			get { return _request; }
			set
			{
				_request = value;
				OnPropertyChanged("Request");
			}
		}
		#endregion Request

		#endregion Properties
	}

	/// <summary>A generic OneAll response.</summary>
	/// <typeparam name="TData">The type of the responses result data.</typeparam>
	[DataContract(Name = "response")]
	public class Response<TData> : Response where TData : BaseObject, new()
	{
		#region Member Variables

		/// <summary>The result of the response.</summary>
		private Result<TData> _result = new Result<TData>();

		#endregion Member Variables

		#region Properties

		#region Result
		/// <summary>The result of the response.</summary>
		[DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
		public Result<TData> Result
		{
			get { return _result; }
			set
			{
				_result = value;
				OnPropertyChanged("Result");
			}
		}
		#endregion Result

		#endregion Properties
	}
}