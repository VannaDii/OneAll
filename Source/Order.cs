using System;
using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>Describes how a collection of items is ordered or sorted.</summary>
	[DataContract(Name = "order")]
	public class Order : BaseObject
	{
		#region Member Variables

		/// <summary>The field to which the order or sort applies.</summary>
		private string _field = string.Empty;

		/// <summary>The direction in which the field is ordered or sorted.</summary>
		[DataMember(Name = "direction", IsRequired = false, EmitDefaultValue = false)]
		private string _directionString = string.Empty;

		#endregion Member Variables

		#region Properties

		#region Field
		/// <summary>The field to which the order or sort applies.</summary>
		[DataMember(Name = "field", IsRequired = false, EmitDefaultValue = false)]
		public string Field
		{
			get { return _field; }
			set
			{
				_field = value;
				OnPropertyChanged("Field");
			}
		}
		#endregion Field

		#region Direction
		/// <summary>The direction in which the field is ordered or sorted.</summary>
		[IgnoreDataMember()]
		public OneAllDirection Direction
		{
			get
			{
				bool parsed = true;
				OneAllDirection retVal = OneAllDirection.Invalid;

				try { retVal = (OneAllDirection)Enum.Parse(typeof(OneAllDirection), _directionString, true); }
				catch (ArgumentNullException) { parsed = false; }
				catch (ArgumentException) { parsed = false; }
				catch (OverflowException) { parsed = false; }

				return (parsed ? retVal : OneAllDirection.Invalid);
			}
			set
			{
				_directionString = value.ToString();
				OnPropertyChanged("Direction");
			}
		}
		#endregion Direction

		#endregion Properties
	}
}
