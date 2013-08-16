using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>A standard OneAll identity collection on a user.</summary>
	[DataContract()]
	public class IdentityList : BaseObject
	{
		#region Member Variables

		/// <summary>The identities.</summary>
		[DataMember(Name = "identity", IsRequired = false, EmitDefaultValue = false)]
		private BaseCollection<Identity> _identity = new BaseCollection<Identity>();

		#endregion Member Variables

		#region Properties

		#region Identity
		/// <summary>The identities.</summary>
		public BaseCollection<Identity> Identity
		{
			get { return _identity; }
		}
		#endregion Identity

		#endregion Properties
	}
}