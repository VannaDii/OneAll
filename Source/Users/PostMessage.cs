using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll message to publish for a user.</summary>
	[DataContract()]
	public class PostMessage : BaseObject
	{
		#region Member Variables

		/// <summary>The parts.</summary>
		private MessageParts _parts = null;

		/// <summary>The providers.</summary>
		Collection<string> _providers = new Collection<string>();

		#endregion Member Variables

		#region Properties

		#region Parts
		/// <summary>The parts.</summary>
		[DataMember(Name = "parts", IsRequired = false, EmitDefaultValue = false)]
		public MessageParts Parts
		{
			get { return _parts; }
			set { _parts = value; OnPropertyChanged("Parts"); }
		}
		#endregion Parts

		#region Providers
		/// <summary>The providers.</summary>
		[DataMember(Name = "providers", IsRequired = false, EmitDefaultValue = false)]
		public Collection<string> Providers
		{
			get { return _providers; }
		}
		#endregion Providers

		#endregion Properties
	}
}