using System.Runtime.Serialization;

namespace OneAll.Users
{
	/// <summary>Represents an email of an identity.</summary>
	[DataContract(Name = "email")]
	public class Email : BaseObject
	{
		#region Member Variables

		/// <summary>Is verified.</summary>
		private bool _isVerifiedAddress = false;

		/// <summary>The email address.</summary>
		private string _emailValue = string.Empty;

		#endregion Member Variables

		#region Properties

		#region IsVerified
		/// <summary>Is verified.</summary>
		[DataMember(Name = "is_verified", IsRequired = false, EmitDefaultValue = false)]
		public bool IsVerified
		{
			get { return _isVerifiedAddress; }
			set { _isVerifiedAddress = value; OnPropertyChanged("IsVerified"); }
		}
		#endregion IsVerified

		#region Value
		/// <summary>The email address.</summary>
		[DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
		public string Value
		{
			get { return _emailValue; }
			set { _emailValue = value; OnPropertyChanged("Value"); }
		}
		#endregion Value

		#endregion Properties
	}
}