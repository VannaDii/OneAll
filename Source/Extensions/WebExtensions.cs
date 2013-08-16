using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace OneAll
{
	/// <summary>Extensions used on web requests and responses.</summary>
	public static class WebExtensions
	{
		#region Methods

		#region ResolveFullUrl
		/// <summary>Resolves a relative URL to a full URL based on the current context.</summary>
		/// <param name="url">The relative URL.</param>
		/// <returns>The full URL.</returns>
		internal static Uri ResolveFullUrl(this Uri url)
		{
			return (HttpContext.Current != null && HttpContext.Current.Request != null ?
				new Uri(HttpContext.Current.Request.Url, url) : url);
		}
		#endregion ResolveFullUrl

		#region SetBasicAuth
		/// <summary>Sets the request to use a basic authentication credential and header.</summary>
		/// <param name="request">The request.</param>
		/// <param name="cred">The credential.</param>
		internal static void SetBasicAuth(this HttpWebRequest request, Credential cred)
		{
			if (request != null && cred != null && cred.IsValid())
			{
				CredentialCache cache = new CredentialCache();
				NetworkCredential realCred = new NetworkCredential(cred.PublicKey, cred.PrivateKey.ToUnsecureString());
				cache.Add(request.RequestUri, OneAllConstants.CRED_BASIC, realCred);

				request.UseDefaultCredentials = false;
				request.Credentials = cache;
				request.UserAgent = string.Format(CultureInfo.InvariantCulture, OneAllConstants.FORMAT_USER_AGENT, Assembly.GetExecutingAssembly().GetName().Version.ToString(4));
				request.Headers.Add(OneAllConstants.HEAD_AUTHORIZATION, string.Format(CultureInfo.InvariantCulture, OneAllConstants.HEAD_BASIC,
					Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format(CultureInfo.InvariantCulture,
					OneAllConstants.HEAD_BASIC_CRED, realCred.UserName, realCred.Password)))));
			}
		}
		#endregion SetBasicAuth

		#region SetHTTPMethod
		/// <summary>Sets the request for the appropriate HTTP method based on the <see cref="OneAllMethod" />.</summary>
		/// <param name="request">The request.</param>
		/// <param name="method">The OneAll method.</param>
		internal static void SetHTTPMethod(this HttpWebRequest request, OneAllMethod method)
		{
			if (request != null && Enum.IsDefined(typeof(OneAllMethod), method))
			{
				switch (method)
				{
					case OneAllMethod.Invalid: { throw new ArgumentException(OneAllConstants.ERR_INVALID_HTTP_METHOD, OneAllConstants.PARAM_METHOD); };
					default: { request.Method = method.ToString().ToUpper(CultureInfo.InvariantCulture); } break;
				}
			}
			else { throw new ArgumentException(OneAllConstants.ERR_INVALID_HTTP_METHOD, OneAllConstants.PARAM_METHOD); }
		}
		#endregion SetHTTPMethod

		#endregion Methods
	}
}
