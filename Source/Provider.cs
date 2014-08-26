
namespace OneAll
{
	/// <summary>Represents the basics of a OneAll provider.</summary>
	public class Provider : BaseObject
	{
		#region Member Variables

		/// <summary>The scriptable identifier of the provider.</summary>
		private string _identifier = string.Empty;

		/// <summary>The user friendly name of the provider.</summary>
		private string _name = string.Empty;

		#endregion Member Variables

		#region Properties

		#region Identifier
		/// <summary>The scriptable identifier of the provider.</summary>
		public string Identifier
		{
			get { return _identifier; }
			set { _identifier = value; OnPropertyChanged("Identifier"); }
		}
		#endregion Identifier

		#region Name
		/// <summary>The user friendly name of the provider.</summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; OnPropertyChanged("Name"); }
		}
		#endregion Name

		#endregion Properties
	}
}