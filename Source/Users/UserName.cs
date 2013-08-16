using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>Represents the name of the identity of the user on a connection.</summary>
	[DataContract(Name = "name")]
	public class UserName : BaseObject
	{
		#region Member Variables

		/// <summary>The formatted.</summary>
		private string _formatted;

		#endregion Member Variables

		#region Properties

		#region Formatted
		/// <summary>The formatted.</summary>
		[DataMember(Name = "formatted", IsRequired = false, EmitDefaultValue = false)]
		public string Formatted
		{
			get { return _formatted; }
			set { _formatted = value; OnPropertyChanged("Formatted"); }
		}
		#endregion Formatted

		#endregion Properties
	}
}