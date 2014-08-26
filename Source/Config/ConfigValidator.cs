using System;
using System.Configuration;

namespace OneAll.Config
{
	/// <summary>The OneAll configuration validation methods.</summary>
	public static class ConfigValidator
	{
		#region Methods

		#region ValidateUriSecure
		/// <summary>Validates a value is a secure (HTTPS) <see cref="Uri" />.</summary>
		/// <param name="value">The value to be validated.</param>
		public static void ValidateUriSecure(object value)
		{
			if (value == null || !typeof(Uri).IsAssignableFrom(value.GetType()) || !Uri.UriSchemeHttps.Equals((value as Uri).Scheme))
				throw new ConfigurationErrorsException(OneAllConstants.ERR_UNSECURE_URI);
		}
		#endregion ValidateUriSecure

		#endregion Methods
	}
}