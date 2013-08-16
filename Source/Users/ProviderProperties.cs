using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll provider properties on a contact on a user contacts result.</summary>
	[DataContract()]
	public class ProviderProperties : BaseObject
	{
		#region Member Variables

		/// <summary>The flags.</summary>
		private string _indicators = string.Empty;

		/// <summary>The key.</summary>
		private long _key = 0L;

		#endregion Member Variables

		#region Properties

		#region Indicators
		/// <summary>The flags.</summary>
		[DataMember(Name = "flags", IsRequired = false, EmitDefaultValue = false)]
		public string Indicators
		{
			get { return _indicators; }
			set
			{
				_indicators = value;
				OnPropertyChanged("Indicators");
			}
		}
		#endregion Indicators

		#region Key
		/// <summary>The key.</summary>
		[DataMember(Name = "key", IsRequired = false, EmitDefaultValue = false)]
		public long Key
		{
			get { return _key; }
			set
			{
				_key = value;
				OnPropertyChanged("Key");
			}
		}
		#endregion Key

		#endregion Properties
	}
}