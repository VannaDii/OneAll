using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OneAll.Config;
using OneAll.Connections;
using OneAll.Sharing;
using OneAll.Sharing.Analytics;
using OneAll.ShortUrls;
using OneAll.Users;

namespace OneAll
{
	/// <summary>The OneAll Social REST .Net API.</summary>
	public sealed class OneAllAPI
	{
		#region Member Variables

		/// <summary>The default instance of the OneAll API.</summary>
		private static OneAllAPI _default = null;

		/// <summary>The single instance of the OneAll APIs settings.</summary>
		private Settings _settings = null;

		/// <summary>Thread safety locking object.</summary>
		private static object _padLock = new object();

		#endregion Member Variables

		#region Constructors

		/// <summary>Privately creates an instance of the OneAll API.</summary>
		private OneAllAPI() { _settings = Settings.GetInstance(); }

		#endregion Constructors

		#region Properties

		#region Default
		/// <summary>Gets the default instance of the API.</summary>
		public static OneAllAPI Default
		{
			get
			{
				lock (_padLock)
				{
					if (_default == null)
						_default = new OneAllAPI();
				}

				return _default;
			}
		}
		#endregion Default

		#region Settings
		/// <summary>Gets the settings for this instance of the API.</summary>
		public Settings Settings { get { return _settings; } }
		#endregion Instance

		#endregion Properties

		#region Methods

		#region NewInstance
		/// <summary>Gets a new instance of the API initialized with values from the App.config or Web.config file.</summary>
		/// <example>
		/// Example of how to get a new API instance with the configured values:
		/// <code lang="cs">
		/// <![CDATA[
		/// OneAllAPI apiInstance = OneAllAPI.NewInstance();
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="InitializeConfig"/>
		/// <seealso cref="InitializeValues"/>
		/// <returns>A new <see cref="OneAllAPI"/> instance using the current configuration.</returns>
		public static OneAllAPI NewInstance()
		{
			return new OneAllAPI();
		}
		#endregion NewInstance

		#region NewInstance
		/// <summary>Gets a new instance of the API.</summary>
		/// <param name="domain">The domain to be used, or null to use the configured value.</param>
		/// <param name="privateKey">The private key to be used, or null to use the configured value.</param>
		/// <param name="publicKey">The public key to be used, or null to use the configured value.</param>
		/// <param name="logOnDisplay">The display settings for the log on script.</param>
		/// <param name="linkDisplay">The display settings for the link/connect script.</param>
		/// <param name="authProviders">The provider names which will be supported for authentication.</param>
		/// <param name="shareProviders">The providers which will be supported for sharing.</param>
		/// <example>
		/// Example of how to get a new API instance with the configured values:
		/// <code lang="cs">
		/// <![CDATA[
		/// Uri yourOneAllApiSite = new Uri("https://yoursite.api.oneall.com"); // This MUST be HTTPS or an InvalidArgumentException will be thrown.
		/// string yourPrivateKey = "YOUR_PRIVATE_KEY";
		/// string yourPublicKey = "YOUR_PUBLIC_KEY";
		/// DisplaySettings yourLogOnDisplay = new DisplaySettings() { Callback = new Uri("http://yoursite.com/account/logon"), Height = 5, Width = 2, Theme = OneAllConstants.PlugInThemeSignIn };
		/// DisplaySettings yourLinkDisplay = new DisplaySettings() { Callback = new Uri("http://yoursite.com/account/link"), Height = 5, Width = 2, Theme = OneAllConstants.PlugInThemeConnect };
		/// string[] yourAuthProviders = new string[] { "facebook", "twitter", "google", "yahoo", "windowslive" };
		/// string[] yourShareProviders = new string[] { "facebook", "reddit", "google_bookmarks", "stumbleupon", "twitter_tweet_but" };
		/// 
		/// OneAllAPI apiInstance = OneAllAPI.NewInstance(yourOneAllApiSite, yourPrivateKey, yourPublicKey, yourLogOnDisplay, yourLinkDisplay, yourAuthProviders, yourShareProviders);
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="DisplaySettings"/>
		/// <seealso cref="Provider"/>
		/// <seealso cref="InitializeConfig"/>
		/// <seealso cref="InitializeValues"/>
		/// <returns>A new <see cref="OneAllAPI"/> instance using the specified settings..</returns>
		public static OneAllAPI NewInstance(Uri domain, string privateKey, string publicKey, DisplaySettings logOnDisplay, DisplaySettings linkDisplay, IEnumerable<string> authProviders, IEnumerable<Provider> shareProviders)
		{
			OneAllAPI retVal = new OneAllAPI();
			retVal.InitializeValues(domain, privateKey, publicKey, logOnDisplay, linkDisplay, authProviders, shareProviders);

			return retVal;
		}
		#endregion NewInstance

		#region InitializeConfig
		/// <summary>Initializes the settings from the current configuration.</summary>
		/// <example>
		/// Example of how to initialize (or reinitialize) the default API instance to the configured values:
		/// <code lang="cs">
		/// <![CDATA[
		/// OneAllAPI.Default.InitializeConfig();
		/// ]]>
		/// </code>
		/// <br />
		/// Example of how to initialize (or reinitialize) an API instance to the configured values:
		/// <code lang="cs">
		/// <![CDATA[
		/// OneAllAPI apiInstance = OneAllAPI.NewInstance();
		/// apiInstance.InitializeConfig();
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="InitializeValues"/>
		public void InitializeConfig()
		{
			Settings.InitializeConfig();
		}
		#endregion InitializeConfig

		#region InitializeValues
		/// <summary>Initializes the instance with the specified values. The specified non-null values will override any configured values.</summary>
		/// <param name="domain">The domain to be used, or null to use the configured value.</param>
		/// <param name="privateKey">The private key to be used, or null to use the configured value.</param>
		/// <param name="publicKey">The public key to be used, or null to use the configured value.</param>
		/// <param name="logOnDisplay">The display settings for the log on script.</param>
		/// <param name="linkDisplay">The display settings for the link/connect script.</param>
		/// <param name="authProviders">The provider names which will be supported for authentication.</param>
		/// <param name="shareProviders">The providers which will be supported for sharing.</param>
		/// <example>
		/// Example of how to initialize the default API instance to specific values:
		/// <code lang="cs">
		/// <![CDATA[
		/// Uri yourOneAllApiSite = new Uri("https://yoursite.api.oneall.com"); // This MUST be HTTPS or an InvalidArgumentException will be thrown.
		/// string yourPrivateKey = "YOUR_PRIVATE_KEY";
		/// string yourPublicKey = "YOUR_PUBLIC_KEY";
		/// DisplaySettings yourLogOnDisplay = new DisplaySettings() { Callback = new Uri("http://yoursite.com/account/logon"), Height = 5, Width = 2, Theme = OneAllConstants.PlugInThemeSignIn };
		/// DisplaySettings yourLinkDisplay = new DisplaySettings() { Callback = new Uri("http://yoursite.com/account/link"), Height = 5, Width = 2, Theme = OneAllConstants.PlugInThemeConnect };
		/// string[] yourAuthProviders = new string[] { "facebook", "twitter", "google", "yahoo", "windowslive" };
		/// string[] yourShareProviders = new string[] { "facebook", "reddit", "google_bookmarks", "stumbleupon", "twitter_tweet_but" };
		/// 
		/// OneAllAPI.Default.InitializeValues(yourOneAllApiSite, yourPrivateKey, yourPublicKey, yourLogOnDisplay, yourLinkDisplay, yourAuthProviders, yourShareProviders);
		/// ]]>
		/// </code>
		/// <br />
		/// In this example null values are provided for the authentication (logon/link) and the sharing providers which will cause them to use the values from the App.config or Web.config files. Example of how to initialize an API instance to specific values:
		/// <code lang="cs">
		/// <![CDATA[
		/// Uri yourOneAllApiSite = new Uri("https://yoursite.api.oneall.com"); // This MUST be HTTPS or an InvalidArgumentException will be thrown.
		/// string yourPrivateKey = "YOUR_PRIVATE_KEY";
		/// string yourPublicKey = "YOUR_PUBLIC_KEY";
		/// DisplaySettings yourLogOnDisplay = new DisplaySettings() { Callback = new Uri("http://yoursite.com/account/logon"), Height = 5, Width = 2, Theme = OneAllConstants.PlugInThemeSignIn };
		/// DisplaySettings yourLinkDisplay = new DisplaySettings() { Callback = new Uri("http://yoursite.com/account/link"), Height = 5, Width = 2, Theme = OneAllConstants.PlugInThemeConnect };
		/// 
		/// OneAllAPI apiInstance = OneAllAPI.NewInstance();
		/// apiInstance.InitializeValues(yourOneAllApiSite, yourPrivateKey, yourPublicKey, yourLogOnDisplay, yourLinkDisplay, null, null);
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="DisplaySettings"/>
		/// <seealso cref="Provider"/>
		/// <seealso cref="InitializeConfig"/>
		/// <exception cref="ArgumentException">If the <paramref name="domain"/> is not within the HTTPS (secure HTTP) protocol.</exception>
		public void InitializeValues(Uri domain, string privateKey, string publicKey, DisplaySettings logOnDisplay, DisplaySettings linkDisplay, IEnumerable<string> authProviders, IEnumerable<Provider> shareProviders)
		{
			Settings.InitializeValues(domain, privateKey, publicKey, logOnDisplay, linkDisplay, authProviders, shareProviders);
		}
		#endregion InitializeValues

		#region ConnectionListAll
		/// <summary>Gets a list of all connections for the current site.</summary>
		/// <example>
		/// Example of how to get all connections for the current (based on initialized values or XML configuration) OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Response<ConnectionListResult> response = OneAllAPI.Default.ConnectionListAll();
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///     response.Result != null && response.Result.Data != null && response.Result.Data.Connections != null &&
		///     response.Result.Data.Connections.Entries != null && response.Result.Data.Connections.Entries.Count > 0)
		/// {
		///     foreach (ConnectionListEntry entry in response.Result.Data.Connections.Entries)
		///         Console.WriteLine(entry.ConnectionToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="ConnectionListResult"/>
		/// <seealso cref="ConnectionReadDetails"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/connections/list-all-connections/">http://docs.oneall.com/api/resources/connections/list-all-connections/</a></remarks>
		/// <returns>A <see cref="Response&lt;ConnectionListResult&gt;"/> representing all connections for a OneAll site.</returns>
		public Response<ConnectionListResult> ConnectionListAll()
		{
			return GetResponse<ConnectionListResult>(new Uri(OneAllConstants.URL_CONNECTION_LISTALL, UriKind.Relative), OneAllMethod.Get);
		}
		#endregion ConnectionListAll

		#region ConnectionReadDetails
		/// <summary>Gets the result of an interaction between one of your users and one the OneAll plug-ins.</summary>
		/// <param name="connectionToken">The unique identifier from a user interaction like logging in or linking.</param>
		/// <example>
		/// Example of how to get connection details for a single connection:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid connectionToken = new Guid("DC427B55-4321-4B05-B2AE-E6321149C3F4"); // This is a fictitious GUID, and returns an error
		/// Response<ConnectionDetail> response = OneAllAPI.Default.ConnectionReadDetails(connectionToken);
		/// if (response != null && response.Request != null && response.Request.Status != null &&
		///     response.Request.Status.Code.Equals(200) && response.Connection != null && response.User)
		/// {
		///     Console.WriteLine("Connection {0}: {1}", response.Connection.ConnectionToken, response.User.Identity.Name)
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="ConnectionDetail"/>
		/// <seealso cref="ConnectionListAll"/>
		/// <returns>A <see cref="Response&lt;ConnectionDetail&gt;"/> representing the details of a single connection for a OneAll site.</returns>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/connections/read-connection-details/">http://docs.oneall.com/api/resources/connections/read-connection-details/</a></remarks>
		public Response<ConnectionDetail> ConnectionReadDetails(Guid connectionToken)
		{
			return GetResponse<ConnectionDetail>(new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_CONNECTION_DETAIL, connectionToken), UriKind.Relative), OneAllMethod.Get);
		}
		#endregion ConnectionReadDetails

		#region GetResponseRaw
		/// <summary>Gets a UTF8 string of data from the <paramref name="url"/>.</summary>
		/// <param name="url">The full or partial URL.</param>
		/// <param name="method">The HTTP method.</param>
		/// <returns>A <see cref="System.String"/> of UTF8 characters.</returns>
		internal string GetResponseRaw(Uri url, OneAllMethod method)
		{
			Uri fullUrl = url.GetFullUrl(Settings);
			return Encoding.UTF8.GetString(BinaryWebClient.Get(fullUrl, method, Settings.Credential, null, null));
		}
		#endregion GetResponseRaw

		#region GetResponseRaw
		/// <summary>Gets a UTF8 string of data from the <paramref name="url"/>.</summary>
		/// <typeparam name="TData">The type of the data object.</typeparam>
		/// <param name="url">The full or partial URL.</param>
		/// <param name="method">The HTTP method.</param>
		/// <param name="data">The data object instance.</param>
		/// <returns>A <see cref="System.String"/> of UTF8 characters.</returns>
		internal string GetResponseRaw<TData>(Uri url, OneAllMethod method, TData data) where TData : Request
		{
			Uri fullUrl = url.GetFullUrl(Settings);
			return Encoding.UTF8.GetString(BinaryWebClient.Post(fullUrl, method, Settings.Credential, Encoding.UTF8.GetBytes(data.ToJson()), null, null));
		}
		#endregion GetResponseRaw

		#region GetResponse
		/// <summary>Gets a <see cref="Response"/> from the <paramref name="url"/>.</summary>
		/// <typeparam name="T">The type of <see cref="Response"/>.</typeparam>
		/// <param name="url">The full or partial URL.</param>
		/// <returns>A <see cref="Response"/> instance.</returns>
		internal Response<T> GetResponse<T>(Uri url)
			where T : BaseObject, new()
		{
			return GetResponse<T>(url, OneAllMethod.Get);
		}
		#endregion GetResponse

		#region GetResponse
		/// <summary>Gets a <see cref="Response"/> from the <paramref name="url"/>.</summary>
		/// <param name="url">The full or partial URL.</param>
		/// <param name="method">The HTTP method.</param>
		/// <returns>A <see cref="Response"/> instance.</returns>
		internal Response GetResponse(Uri url, OneAllMethod method)
		{
			Response retVal = null;
			string json = GetResponseRaw(url, method);
			if (!string.IsNullOrEmpty(json)) retVal = retVal.FromJson(json);

			return retVal;
		}
		#endregion GetResponse

		#region GetResponse
		/// <summary>Gets a <see cref="Response"/> from the <paramref name="url"/>.</summary>
		/// <typeparam name="T">The type of <see cref="Response"/>.</typeparam>
		/// <param name="url">The full or partial URL.</param>
		/// <param name="method">The HTTP method.</param>
		/// <returns>A <see cref="Response"/> instance.</returns>
		internal Response<T> GetResponse<T>(Uri url, OneAllMethod method)
			where T : BaseObject, new()
		{
			Response<T> retVal = null;
			string json = GetResponseRaw(url, method);
			if (!string.IsNullOrEmpty(json)) retVal = retVal.FromJson(json);

			return retVal;
		}
		#endregion GetResponse

		#region GetResponse
		/// <summary>Gets a <see cref="Response"/> from the <paramref name="url"/>.</summary>
		/// <typeparam name="T">The type of <see cref="Response"/>.</typeparam>
		/// <typeparam name="TData">The type of the data object.</typeparam>
		/// <param name="url">The full or partial URL.</param>
		/// <param name="method">The HTTP method.</param>
		/// <param name="data">The data object instance.</param>
		/// <returns>A <see cref="Response"/> instance.</returns>
		internal Response<T> GetResponse<T, TData>(Uri url, OneAllMethod method, TData data)
			where T : BaseObject, new()
			where TData : Request
		{
			Response<T> retVal = null;
			string json = GetResponseRaw(url, method, data);
			if (!string.IsNullOrEmpty(json)) retVal = retVal.FromJson(json);

			return retVal;
		}
		#endregion GetResponse

		#region ShortUrlCreate
		/// <summary>Shortens a URL.</summary>
		/// <param name="url">The full original URL to be shortened.</param>
		/// <example>
		/// Example of how to create/shorten a full URL:
		/// <code lang="cs">
		/// <![CDATA[
		/// Uri shortUrl = null;
		/// Uri fullUrl = new Uri("http://www.xpglive.com");
		/// Response<UrlResult> response = OneAllAPI.Default.ShortUrlCreate(fullUrl);
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///     response.Result != null && response.Result.Data && response.Result.Data.ShortenedUrl && response.Result.Data.ShortenedUrl.ShortenedUrl)
		/// {
		///     shortUrl = response.Result.Data.ShortenedUrl.ShortenedUrl;
		///     Console.WriteLine("URL {0} shortened to {1}", fullUrl, shortUrl);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="UrlResult"/>
		/// <seealso cref="ShortUrlRead"/>
		/// <seealso cref="ShortUrlListAll"/>
		/// <seealso cref="ShortUrlDelete"/>
		/// <returns>A <see cref="Response&lt;UrlResult&gt;"/> representing the shortened version of the full URL.</returns>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/shorturls/create-shorturl/">http://docs.oneall.com/api/resources/shorturls/create-shorturl/</a></remarks>
		public Response<UrlResult> ShortUrlCreate(Uri url)
		{
			return GetResponse<UrlResult, UrlRequest>(new Uri(OneAllConstants.URL_SHORTENED_URL_CREATE_LIST, UriKind.Relative), OneAllMethod.Post,
				new UrlRequest() { ShortenedUrl = new Url() { OriginalUrl = url } });
		}
		#endregion ShortUrlCreate

		#region ShortUrlDelete
		/// <summary>Deletes a previously created short URL.</summary>
		/// <param name="shortenedToken">The short URL token.</param>
		/// <example>
		/// Example of how to create and then delete a short URL:
		/// <code lang="cs">
		/// <![CDATA[
		/// Uri shortUrl = null;
		/// string token = string.Empty;
		/// Uri fullUrl = new Uri("http://www.xpglive.com");
		/// 
		/// Response responseDelete = null;
		/// Response<UrlResult> responseCreate = OneAllAPI.Default.ShortUrlCreate(fullUrl);
		/// 
		/// if (responseCreate != null && responseCreate.Request != null && responseCreate.Request.Status != null &&
		///		responseCreate.Request.Status.code.Equals(200) && responseCreate.Result != null &&
		///		responseCreate.Result.Data && responseCreate.Result.Data.ShortenedUrl &&
		///		responseCreate.Result.Data.ShortenedUrl.ShortenedUrl)
		/// {
		///		token = response.Result.Data.ShortenedUrl.Token;
		///     shortUrl = response.Result.Data.ShortenedUrl.ShortenedUrl;
		///     Console.WriteLine("URL {0} shortened to {1}", fullUrl, shortUrl);
		///     
		///		if (!string.IsNullOrEmpty(token))
		///		{
		///			responseDelete = OneAllAPI.Default.ShortUrlDelete(token);
		///			if (responseDelete != null && responseDelete.Request != null && responseDelete.Request.Status != null)
		///				Console.WriteLine(responseDelete.Request.Status.Info);
		///		}
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="ShortUrlCreate"/>
		/// <seealso cref="ShortUrlRead"/>
		/// <seealso cref="ShortUrlListAll"/>
		/// <returns>A <see cref="Response"/> indicating the result of the operation.</returns>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/shorturls/delete-shorturl/">http://docs.oneall.com/api/resources/shorturls/delete-shorturl/</a></remarks>
		public Response ShortUrlDelete(string shortenedToken)
		{
			return GetResponse<Response>(new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_SHORTENED_URL_DELETE, shortenedToken), UriKind.Relative), OneAllMethod.Delete);
		}
		#endregion ShortUrlDelete

		#region ShortUrlListAll
		/// <summary>Gets a list of previously created/shortened URLs.</summary>
		/// <example>
		/// Example of how to list all previously created/shortened URLs:
		/// <code lang="cs">
		/// <![CDATA[
		/// Response<UrlListResult> response = OneAllAPI.Default.ShortUrlListAll();
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///     response.Result != null && response.Result.Data && response.Result.Data.ShortenedUrls && response.Result.Data.ShortenedUrls.Entries != null)
		/// {
		///		foreach(SimpleUrl entry in response.Result.Data.ShortenedUrls.Entries)
		///			Console.WriteLine("URL {0} shortened to {1}", entry.OriginalUrl, entry.ShortenedUrl);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="SimpleUrl"/>
		/// <seealso cref="UrlListResult"/>
		/// <seealso cref="ShortUrlCreate"/>
		/// <seealso cref="ShortUrlRead"/>
		/// <seealso cref="ShortUrlDelete"/>
		/// <returns>A <see cref="Response&lt;UrlListResult&gt;"/> containing a list of previously created/shortened URLs.</returns>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/shorturls/list-all-shorturls/">http://docs.oneall.com/api/resources/shorturls/list-all-shorturls/</a></remarks>
		public Response<UrlListResult> ShortUrlListAll()
		{
			return GetResponse<UrlListResult>(new Uri(OneAllConstants.URL_SHORTENED_URL_CREATE_LIST, UriKind.Relative), OneAllMethod.Get);
		}
		#endregion ShortUrlListAll

		#region ShortUrlRead
		/// <summary>Reads the details of a short URL.</summary>
		/// <param name="shortenedToken">The short URL token.</param>
		/// <example>
		/// Example of how to get the details of a previously created/shortened URL:
		/// <code lang="cs">
		/// <![CDATA[
		/// Uri shortUrl = null;
		/// string token = "HxwWM"; // This is a fictitious token and will cause an error.
		/// 
		/// Response<UrlResult> response = OneAllAPI.Default.ShortUrlRead();
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///     response.Result != null && response.Result.Data && response.Result.Data.ShortenedUrl && response.Result.Data.ShortenedUrl.ShortenedUrl)
		/// {
		///     shortUrl = response.Result.Data.ShortenedUrl.ShortenedUrl;
		///     Console.WriteLine("Short URL {0}", shortUrl);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="UrlResult"/>
		/// <seealso cref="ShortUrlCreate"/>
		/// <seealso cref="ShortUrlListAll"/>
		/// <seealso cref="ShortUrlDelete"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/shorturls/read-shorturl-details/">http://docs.oneall.com/api/resources/shorturls/read-shorturl-details/</a></remarks>
		/// <returns>A <see cref="Response&lt;UrlResult&gt;"/> representing the details of previously created/shortened URL.</returns>
		public Response<UrlResult> ShortUrlRead(string shortenedToken)
		{
			return GetResponse<UrlResult>(new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_SHORTENED_URL_DETAIL, shortenedToken), UriKind.Relative), OneAllMethod.Get);
		}
		#endregion ShortUrlRead

		#region UserDelete
		/// <summary>Delete one of your users.</summary>
		/// <param name="token">The unique identifier of a OneAll user.</param>
		/// <example>
		/// Example of how to delete a user from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid userToken = new Guid("D8F32DDE-0F46-4FB5-B935-D03DE623CC91"); // This is a fictitious token and will return an error.
		/// 
		/// Response response = OneAllAPI.Default.UserDelete(userToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200))
		/// {
		///     Console.WriteLine("User with id \"{0}\" has been permanently deleted from your site.", userToken);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="UserListAll"/>
		/// <seealso cref="UserReadDetails"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/users/delete-user/">http://docs.oneall.com/api/resources/users/delete-user/</a></remarks>
		/// <returns>A <see cref="Response"/> indicating the result of the operation.</returns>
		public Response UserDelete(Guid token)
		{
			return GetResponse<Response>(new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_USER_DELETE, token), UriKind.Relative), OneAllMethod.Delete);
		}
		#endregion UserDelete

		#region UserListAll
		/// <summary>Gets a list of all your users.</summary>
		/// <example>
		/// Example of how to list all users from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Response<UserListResult> response = OneAllAPI.Default.UserListAll();
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.Users != null && response.Result.Data.Users.Entries != null)
		/// {
		///     foreach (User entry in response.Result.Data.Users.Entries)
		///         Console.WriteLine(entry.UserToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="UserListResult"/>
		/// <seealso cref="User"/>
		/// <seealso cref="UserDelete"/>
		/// <seealso cref="UserReadDetails"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/users/list-all-users/">http://docs.oneall.com/api/resources/users/list-all-users/</a></remarks>
		/// <returns>A <see cref="Response&lt;UserListResult&gt;"/> representing all of the users from your OneAll site.</returns>
		public Response<UserListResult> UserListAll()
		{
			return GetResponse<UserListResult>(new Uri(OneAllConstants.URL_USER_LISTALL, UriKind.Relative), OneAllMethod.Get);
		}
		#endregion UserListAll

		#region UserReadDetails
		/// <summary>Gets the details of for a user.</summary>
		/// <param name="token">The unique identifier of a OneAll user.</param>
		/// <example>
		/// Example of how to get the details of a single user from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid userToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		/// Response<UserResult> response = OneAllAPI.Default.UserReadDetails(userToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.User != null)
		/// {
		///     Console.WriteLine(response.Result.Data.User.UserToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="UserResult"/>
		/// <seealso cref="User"/>
		/// <seealso cref="UserDelete"/>
		/// <seealso cref="UserListAll"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/users/read-user-details/">http://docs.oneall.com/api/resources/users/read-user-details/</a></remarks>
		/// <returns>A <see cref="Response&lt;UserResult&gt;"/> representing the details of a single user from your OneAll site.</returns>
		public Response<UserResult> UserReadDetails(Guid token)
		{
			return GetResponse<UserResult>(new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_USER_DETAIL, token), UriKind.Relative));
		}
		#endregion UserReadDetails

		#region UserPublishContent
		/// <summary>Publishes content to a user's social network.</summary>
		/// <param name="token">The unique identifier of a OneAll user.</param>
		/// <param name="message">The content to be published.</param>
		/// <example>
		/// Example of how to publish content on behalf of a single user from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid userToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		/// PostMessage message = new PostMessage()
		/// {
		///     Parts = new MessageParts()
		///     {
		///         Text = new MessageText() { Body = "A multi provider post on " + DateTime.Now.ToString() },
		///         Video = new MessageVideo() { Url = new Uri("http://youtu.be/VEuMgogl8eY") },
		///         Picture = new MessagePicture() { Url = new Uri("http://www.xpglive.com/Content/Site/TopLeftLogo.png") },
		///         Link = new MessageLink()
		///         {
		///             Url = new Uri("http://www.xpglive.com/about"),
		///             Name = "Social Gaming without Limits",
		///             Caption = "Find out more about XPG Live",
		///             Description = "Mobile social gaming & more."
		///         }
		///     }
		/// };
		/// 
		/// Response<PostResult> response = OneAllAPI.Default.UserPublishContent(userToken, message);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.Message != null)
		/// {
		///     Console.WriteLine(response.Result.Data.Message.SharingMessageToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="PostResult"/>
		/// <seealso cref="PostMessage"/>
		/// <seealso cref="MessageParts"/>
		/// <seealso cref="MessageText"/>
		/// <seealso cref="MessageVideo"/>
		/// <seealso cref="MessagePicture"/>
		/// <seealso cref="MessageLink"/>
		/// <seealso cref="PostResultMessage"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/users/read-contacts/">http://docs.oneall.com/api/resources/users/read-contacts/</a></remarks>
		/// <returns>A <see cref="Response&lt;PostResult&gt;"/> representing the detailed response regarding the action.</returns>
		public Response<PostResult> UserPublishContent(Guid token, PostMessage message)
		{
			return GetResponse<PostResult, PostRequest>(new Uri(string.Format(CultureInfo.InvariantCulture,
				OneAllConstants.URL_FORMAT_USER_PUBLISH, token), UriKind.Relative), OneAllMethod.Post,
				new PostRequest() { Message = message });
		}
		#endregion UserPublishContent

		#region UserReadContacts
		/// <summary>Gets the contacts for a user.</summary>
		/// <param name="token">The unique identifier of a OneAll user.</param>
		/// <example>
		/// Example of how to get the contacts of a single user  from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid userToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		/// Response<ContactsResult> response = OneAllAPI.Default.UserReadContacts(userToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && 
		///		(response.Request.Status.Code.Equals(200) || response.Request.Status.Code.Equals(207)) && // 207 is a multi-status, see OneAll documentation for details
		///		response.Result != null && response.Result.Data != null && response.Result.Data.Results != null)
		/// {
		///     foreach(ContacsResultSet resultSet in response.Result.Data.Results)
		///     {
		///			Console.WriteLine("From {0}:", resultSet.Provider);
		///			if (resultset.Contacts != null)
		///			{
		///				foreach(Contact entry in resultset.Contacts)
		///					Console.WriteLine("\t{0}", entry.ProfileUrl);
		///			}
		///			Console.WriteLine();
		///     }
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Request.Status.Code, response.Request.Status.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="ContactsResult"/>
		/// <seealso cref="ContactsResultSet"/>
		/// <seealso cref="Contact"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/users/read-contacts/">http://docs.oneall.com/api/resources/users/read-contacts/</a></remarks>
		/// <returns>A <see cref="Response&lt;ContactsResult&gt;"/> containing multiple set of contacts from providers.</returns>
		public Response<ContactsResult> UserReadContacts(Guid token)
		{
			return GetResponse<ContactsResult>(new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_USER_CONTACTS, token), UriKind.Relative));
		}
		#endregion UserReadContacts

		#region SharingListAll
		/// <summary>Gets the complete list of published messages.</summary>
		/// <example>
		/// Example of how to list all previously shared/published content from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Response<SharingListResult> response = OneAllAPI.Default.SharingListAll();
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.SharingMessages != null && 
		///		response.Result.Data.SharingMessages.Entries != null)
		/// {
		///     foreach (SharingListEntry entry in response.Result.Data.SharingMessages.Entries)
		///         Console.WriteLine(entry.SharingMessageToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SharingListResult"/>
		/// <seealso cref="SharingListEntry"/>
		/// <seealso cref="SharingPublishMessage"/>
		/// <seealso cref="SharingMessageDetails"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, OneAll.Sharing.SharingUser)"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, System.Guid)"/>
		/// <seealso cref="SharingDeleteMessage"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/social-sharing/list-all-messages/">http://docs.oneall.com/api/resources/social-sharing/list-all-messages/</a></remarks>
		/// <returns>A <see cref="Response&lt;SharingListResult&gt;"/> containing all previously shared/published content.</returns>
		public Response<SharingListResult> SharingListAll()
		{
			return GetResponse<SharingListResult>(new Uri(OneAllConstants.URL_SHARING, UriKind.Relative), OneAllMethod.Get);
		}
		#endregion SharingListAll

		#region SharingPublishMessage
		/// <summary>Publishes a new sharing message on behalf of a user.</summary>
		/// <typeparam name="T">The type of the message being published, this can be omitted and derived from the parameter type.</typeparam>
		/// <param name="message">The message to be published.</param>
		/// <example>
		/// Example of how to share/publish content on behalf of a user from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// IdentityRequest message = new IdentityRequest()
		/// {
		///     PublishForIdentity = new IdentityRequestMessage()
		///     {
		///         IdentityToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		///     },
		///     Parts = new SharingMessageParts()
		///     {
		///         Text = new MessageText() { Body = "A Sharing API post" },
		///         Video = new MessageVideo() { Url = new Uri("http://www.xpglive.com/") },
		///         Picture = new MessagePicture() { Url = new Uri("http://www.xpglive.com/favicon.ico") },
		///         Link = new MessageLink()
		///         {
		///             Url = new Uri("http://www.xpglive.com/about"),
		///             Name = "Social Gaming without Limits",
		///             Caption = "Find out more about XPG Live",
		///             Description = "Mobile social gaming & more."
		///         },
		///         Indicator = new TrackingIndicator() { EnableTracking = true }
		///     }
		/// };
		/// 
		/// // The type parameter doesn't have to be specified because it can be derived and validate by the parameter type
		/// Response<SharingResult> response = OneAllAPI.Default.SharingPublishMessage(message);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && 
		///		(response.Request.Status.Code.Equals(200) || response.Request.Status.Code.Equals(207)) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.SharingMessage != null)
		/// {
		///		Console.WriteLine(response.Result.Data.SharingMessage.SharingMessageToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SharingResult"/>
		/// <seealso cref="SharingMessage"/>
		/// <seealso cref="IdentityRequest"/>
		/// <seealso cref="IdentityRequestMessage"/>
		/// <seealso cref="UserSharingRequest"/>
		/// <seealso cref="SharingMessageParts"/>
		/// <seealso cref="MessageText"/>
		/// <seealso cref="MessageVideo"/>
		/// <seealso cref="MessagePicture"/>
		/// <seealso cref="MessageLink"/>
		/// <seealso cref="TrackingIndicator"/>
		/// <seealso cref="SharingListAll"/>
		/// <seealso cref="SharingMessageDetails"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, OneAll.Sharing.SharingUser)"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, System.Guid)"/>
		/// <seealso cref="SharingDeleteMessage"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/social-sharing/publish-new-message/">http://docs.oneall.com/api/resources/social-sharing/publish-new-message/</a></remarks>
		/// <returns>A <see cref="Response&lt;SharingResult&gt;"/> describing the results of the operation. WHen publishing to multiple networks at once this method may result in a code 207, in this case you'll need to check the status for each publication.</returns>
		public Response<SharingResult> SharingPublishMessage<T>(T message) where T : RequestMessage
		{
			return GetResponse<SharingResult, SharingRequest<T>>(new Uri(OneAllConstants.URL_SHARING, UriKind.Relative),
				OneAllMethod.Post, new SharingRequest<T>() { SharingMessage = message });
		}
		#endregion SharingPublishMessage

		#region SharingMessageDetails
		/// <summary>Gets the details of a previously published message.</summary>
		/// <param name="messageToken">The unique identifier of a message.</param>
		/// <example>
		/// Example of how to share/publish content on behalf of a user from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid messageToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		/// Response<SharingResult> response = OneAllAPI.Default.SharingMessageDetails(messageToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.SharingMessage != null)
		/// {
		///		Console.WriteLine(response.Result.Data.SharingMessage.SharingMessageToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SharingResult"/>
		/// <seealso cref="SharingMessage"/>
		/// <seealso cref="SharingListAll"/>
		/// <seealso cref="SharingPublishMessage"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, OneAll.Sharing.SharingUser)"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, System.Guid)"/>
		/// <seealso cref="SharingDeleteMessage"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/social-sharing/read-message/">http://docs.oneall.com/api/resources/social-sharing/read-message/</a></remarks>
		/// <returns>A <see cref="Response&lt;SharingResult&gt;"/> representing the details of previously shared/published content.</returns>
		public Response<SharingResult> SharingMessageDetails(Guid messageToken)
		{
			return GetResponse<SharingResult>(new Uri(string.Format(CultureInfo.InvariantCulture,
				OneAllConstants.URL_FORMAT_SHARING, messageToken), UriKind.Relative), OneAllMethod.Get);
		}
		#endregion SharingMessageDetails

		#region SharingRePublishMessage
		/// <summary>Publishes a previously published message to other social networks.</summary>
		/// <param name="messageToken">The unique identifier of a message.</param>
		/// <param name="request">The user and network details used to re-publish.</param>
		/// <example>
		/// Example of how to share/publish content targeting a user from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid messageToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		/// 
		/// SharingUser targetUser = new SharingUser();
		/// targetUser.UserToken = new Guid("B428C021-7B88-4474-984D-0FE90CA181EF"); // This is a fictitious token and will return an error.
		/// targetUser.Providers.Add("twitter"); // Provider names can be identified by logging into your OneAll account
		/// targetUser.Providers.Add("facebook");
		/// 
		/// Response<SharingResult> response = OneAllAPI.Default.SharingRePublishMessage(messageToken, shareUser);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && 
		///		(response.Request.Status.Code.Equals(200) || response.Request.Status.Code.Equals(207)) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.SharingMessage != null)
		/// {
		///		Console.WriteLine(response.Result.Data.SharingMessage.SharingMessageToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SharingResult"/>
		/// <seealso cref="SharingMessage"/>
		/// <seealso cref="SharingListAll"/>
		/// <seealso cref="SharingPublishMessage"/>
		/// <seealso cref="SharingMessageDetails"/>
		/// <seealso cref="SharingDeleteMessage"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/social-sharing/re-publish-message/">http://docs.oneall.com/api/resources/social-sharing/re-publish-message/</a></remarks>
		/// <returns>A <see cref="Response&lt;SharingResult&gt;"/> representing the details of re-shared/re-published content and the operation.</returns>
		public Response<SharingResult> SharingRePublishMessage(Guid messageToken, SharingUser request)
		{
			return GetResponse<SharingResult, SharingRequest<UserSharingRequest>>(
				new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_SHARING, messageToken),
				UriKind.Relative), OneAllMethod.Post, new SharingRequest<UserSharingRequest>()
				{
					SharingMessage = new UserSharingRequest() { PublishForUser = request }
				});
		}
		#endregion SharingRePublishMessage

		#region SharingRePublishMessage
		/// <summary>Publishes a previously published message to other social networks.</summary>
		/// <param name="messageToken">The unique identifier of a message.</param>
		/// <param name="identityToken">The unique identifier of the target OneAll user.</param>
		/// <example>
		/// Example of how to share/publish content targeting a user from your OneAll site:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid messageToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		/// Guid userToken = new Guid("B428C021-7B88-4474-984D-0FE90CA181EF"); // This is a fictitious token and will return an error.
		/// 
		/// Response<SharingResult> response = OneAllAPI.Default.SharingRePublishMessage(messageToken, userToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && 
		///		(response.Request.Status.Code.Equals(200) || response.Request.Status.Code.Equals(207)) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.SharingMessage != null)
		/// {
		///		Console.WriteLine(response.Result.Data.SharingMessage.SharingMessageToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SharingResult"/>
		/// <seealso cref="SharingMessage"/>
		/// <seealso cref="SharingListAll"/>
		/// <seealso cref="SharingPublishMessage"/>
		/// <seealso cref="SharingMessageDetails"/>
		/// <seealso cref="SharingDeleteMessage"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/social-sharing/re-publish-message/">http://docs.oneall.com/api/resources/social-sharing/re-publish-message/</a></remarks>
		/// <returns>A <see cref="Response&lt;SharingResult&gt;"/> representing the details of re-shared/re-published content and the operation.</returns>
		public Response<SharingResult> SharingRePublishMessage(Guid messageToken, Guid identityToken)
		{
			return GetResponse<SharingResult, SharingRequest<IdentityRequest>>(
				new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_SHARING, messageToken), UriKind.Relative),
				OneAllMethod.Post, new SharingRequest<IdentityRequest>()
				{
					SharingMessage = new IdentityRequest()
					{
						PublishForIdentity = new IdentityRequestMessage() { IdentityToken = identityToken }
					}
				});
		}
		#endregion SharingRePublishMessage

		#region SharingDeleteMessage
		/// <summary>Permanently deletes an existing sharing message.</summary>
		/// <param name="messageToken">The unique identifier of a message.</param>
		/// <example>
		/// Example of how to deleted previously shared/published content:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid messageToken = new Guid("D2B5F3A5-3834-4EBA-B76F-369EDD01F499"); // This is a fictitious token and will return an error.
		/// 
		/// Response response = OneAllAPI.Default.SharingDeleteMessage(messageToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null &&  response.Request.Status.Code.Equals(200))
		/// {
		///		Console.WriteLine("Message {0:D} has been deleted", messageToken);
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SharingListAll"/>
		/// <seealso cref="SharingPublishMessage"/>
		/// <seealso cref="SharingMessageDetails"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, OneAll.Sharing.SharingUser)"/>
		/// <seealso cref="SharingRePublishMessage(System.Guid, System.Guid)"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/social-sharing/delete-message/">http://docs.oneall.com/api/resources/social-sharing/delete-message/</a></remarks>
		/// <returns>A <see cref="Response"/> indicating the result of the operation.</returns>
		public Response SharingDeleteMessage(Guid messageToken)
		{
			return GetResponse(new Uri(string.Format(CultureInfo.InvariantCulture, OneAllConstants.URL_FORMAT_SHARING_DELETE, messageToken), UriKind.Relative), OneAllMethod.Delete);
		}
		#endregion SharingDeleteMessage

		#region SharingAnalyticsListSnapshots
		/// <summary>Gets the list of your snapshots.</summary>
		/// <example>
		/// Example of how to retrieve a list of all your sharing analytics snapshots:
		/// <code lang="cs">
		/// <![CDATA[
		/// Response<SnapshotListResult> response = OneAllAPI.Default.SharingAnalyticsListSnapshots();
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.Snapshots != null &&
		///		response.Result.Data.Snapshots.Entries != null)
		/// {
		///     foreach (Snapshot entry in response.Result.Data.Snapshots.Entries)
		///         Console.WriteLine(entry.SnapshotToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SnapshotListResult"/>
		/// <seealso cref="Snapshot"/>
		/// <seealso cref="SharingAnalyticsGetSnapshot"/>
		/// <seealso cref="SharingAnalyticsNewSnapshot"/>
		/// <seealso cref="SharingAnalyticsDeleteSnapshot"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/sharing-analytics/list-all-snapshots/">http://docs.oneall.com/api/resources/sharing-analytics/list-all-snapshots/</a></remarks>
		/// <returns>A <see cref="Response&lt;SnapshotListResult&gt;"/> containing a list of previously compiled analytics snapshots.</returns>
		public Response<SnapshotListResult> SharingAnalyticsListSnapshots()
		{
			return GetResponse<SnapshotListResult>(new Uri(OneAllConstants.URL_FORMAT_SHARING_ANALYTICS_LIST, UriKind.Relative), OneAllMethod.Get);
		}
		#endregion SharingAnalyticsListSnapshots

		#region SharingAnalyticsGetSnapshot
		/// <summary>Get the details of an existing snapshot.</summary>
		/// <param name="snapshotToken">The unique identifier of an existing snapshot.</param>
		/// <example>
		/// Example of how to retrieve a completed sharing analytics snapshot:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid snapshotToken = new Guid("328ef915-da13-4b58-83f6-6a35af3b08c0"); // This is a fictitious Guid and will return an error
		/// Response<CompletedSnapshot> response = OneAllAPI.Default.SharingAnalyticsGetSnapshot(snapshotToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.Snapshot != null)
		/// {
		///		Console.WriteLine(response.Result.Data.Snapshot.SnapshotToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="CompletedSnapshotResult"/>
		/// <seealso cref="CompletedSnapshot"/>
		/// <seealso cref="SharingAnalyticsListSnapshots"/>
		/// <seealso cref="SharingAnalyticsNewSnapshot"/>
		/// <seealso cref="SharingAnalyticsDeleteSnapshot"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/sharing-analytics/read-snapshot-details/">http://docs.oneall.com/api/resources/sharing-analytics/read-snapshot-details/</a></remarks>
		/// <returns>A <see cref="Response&lt;CompletedSnapshotResult&gt;"/> representing the details of a previously compiled analytic snapshot.</returns>
		public Response<CompletedSnapshotResult> SharingAnalyticsGetSnapshot(Guid snapshotToken)
		{
			return GetResponse<CompletedSnapshotResult>(new Uri(string.Format(CultureInfo.InvariantCulture,
				OneAllConstants.URL_FORMAT_SHARING_ANALYTICS_DETAILS, snapshotToken), UriKind.Relative), OneAllMethod.Get);
		}
		#endregion SharingAnalyticsGetSnapshot

		#region SharingAnalyticsNewSnapshot
		/// <summary>Initiates a snapshot of a previously published message.</summary>
		/// <param name="messageToken">The unique identifier of a message.</param>
		/// <param name="pingbackUrl">A URL on your server that can handle the response, or null to not be notified. </param>
		/// <example>
		/// Example of how to create a new sharing analytics snapshot:
		/// <code lang="cs">
		/// <![CDATA[
		/// Uri callbackUri = new Uri("http://social.website.com/oneall"); // This is a fictitious URL, use a valid URL on your server or null to not be called back
		/// Guid messageToken = new Guid("1952F4AB-76BD-44DA-B9E0-6D42EC626012"); // This is a fictitious Guid and will return an error
		/// Response<SnapshotResult> response = OneAllAPI.Default.SharingAnalyticsNewSnapshot(messageToken, callbackUri);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200) &&
		///		response.Result != null && response.Result.Data != null && response.Result.Data.Snapshot != null)
		/// {
		///		// This snapshot token can be used to call the SharingAnalyticsGetSnapshot method 
		///		// and check the status of the snapshot if you didn't provide a callback URL.
		///		Console.WriteLine(response.Result.Data.Snapshot.SnapshotToken.ToString("D"));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SnapshotResult"/>
		/// <seealso cref="Snapshot"/>
		/// <seealso cref="SharingAnalyticsListSnapshots"/>
		/// <seealso cref="SharingAnalyticsGetSnapshot"/>
		/// <seealso cref="SharingAnalyticsDeleteSnapshot"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/sharing-analytics/initiate-snapshot/">http://docs.oneall.com/api/resources/sharing-analytics/initiate-snapshot/</a>
		/// <para>The <paramref name="pingbackUrl"/>, if provided, should use the OneAllSharingAnalyticsSnapshot extension method to retrieve data.</para></remarks>
		/// <returns>A <see cref="Response&lt;SnapshotResult&gt;"/> representing the basic information of the new  analytic snapshot.</returns>
		public Response<SnapshotResult> SharingAnalyticsNewSnapshot(Guid messageToken, Uri pingbackUrl)
		{
			return GetResponse<SnapshotResult, SnapshotRequest>(
				new Uri(OneAllConstants.URL_FORMAT_SHARING_ANALYTICS_INITIATE, UriKind.Relative), OneAllMethod.Put,
				new SnapshotRequest()
				{
					Analytics = new SnapshotAnalytics()
					{
						Sharing = new SnapshotAnalyticsDetail()
						{
							MessageToken = messageToken,
							PingbackUri = pingbackUrl
						}
					}
				});
		}
		#endregion SharingAnalyticsNewSnapshot

		#region SharingAnalyticsDeleteSnapshot
		/// <summary>Permanently deletes an existing sharing message.</summary>
		/// <param name="snapshotToken">The unique identifier of an existing snapshot.</param>
		/// <example>
		/// Example of how to create a new sharing analytics snapshot:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid snapshotToken = new Guid("328ef915-da13-4b58-83f6-6a35af3b08c0"); // This is a fictitious Guid and will return an error
		/// Response response = OneAllAPI.Default.SharingAnalyticsDeleteSnapshot(snapshotToken);
		/// 
		/// if (response != null && response.Request != null && response.Request.Status != null && response.Request.Status.Code.Equals(200))
		/// {
		///		Console.WriteLine(string.Format("Snapshot {0} has been deleted.", snapshotToken));
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     Console.WriteLine("{0}: {1}", response.Code, response.Info);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SharingAnalyticsListSnapshots"/>
		/// <seealso cref="SharingAnalyticsGetSnapshot"/>
		/// <seealso cref="SharingAnalyticsNewSnapshot"/>
		/// <remarks>OneAll REST API Documentation: <a target="_blank" href="http://docs.oneall.com/api/resources/sharing-analytics/delete-snapshot/">http://docs.oneall.com/api/resources/sharing-analytics/delete-snapshot/</a></remarks>
		/// <returns>A <see cref="Response"/> indicating the results of the operation.</returns>
		public Response SharingAnalyticsDeleteSnapshot(Guid snapshotToken)
		{
			return GetResponse(new Uri(string.Format(CultureInfo.InvariantCulture,
				OneAllConstants.URL_FORMAT_SHARING_ANALYTICS_DELETE, snapshotToken), UriKind.Relative), OneAllMethod.Delete);
		}
		#endregion SharingAnalyticsDeleteSnapshot

		#endregion Methods
	}
}
