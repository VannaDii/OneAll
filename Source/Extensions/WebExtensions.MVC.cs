using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneAll.Config;
using OneAll.Sharing.Analytics;

namespace OneAll
{
	/// <summary>Extensions used on web requests and responses.</summary>
	public static class WebExtensionsMvc
	{
		#region Methods

		#region OneAllSharingDisplayScript
		/// <summary>Gets the OneAll sharing display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <returns>A string of HTML to cause the sharing API to be rendered.</returns>
		public static MvcHtmlString OneAllSharingDisplayScript(this HtmlHelper helper)
		{
			return OneAllSharingDisplayScript(helper, Settings.Instance.SharingButtonStyle);
		}
		#endregion OneAllSharingDisplayScript

		#region OneAllSharingDisplayScript
		/// <summary>Gets the OneAll sharing display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="style">The desired button style.</param>
		/// <returns>A string of HTML to cause the sharing API to be rendered.</returns>
		public static MvcHtmlString OneAllSharingDisplayScript(this HtmlHelper helper, OneAllButtonStyle style)
		{
			return OneAllSharingDisplayScript(helper, style, Settings.Instance.EnableInsights ?? true);
		}
		#endregion OneAllSharingDisplayScript

		#region OneAllSharingDisplayScript
		/// <summary>Gets the OneAll sharing display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="style">The desired button style.</param>
		/// <param name="socialInsights">True to enable social insights and measure referral traffic.</param>
		/// <returns>A string of HTML to cause the sharing API to be rendered.</returns>
		public static MvcHtmlString OneAllSharingDisplayScript(this HtmlHelper helper, OneAllButtonStyle style, bool socialInsights)
		{
			return OneAllSharingDisplayScript(helper, style, socialInsights, Settings.Instance.TitleFormat);
		}
		#endregion OneAllSharingDisplayScript

		#region OneAllSharingDisplayScript
		/// <summary>Gets the OneAll sharing display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="style">The desired button style.</param>
		/// <param name="socialInsights">True to enable social insights and measure referral traffic.</param>
		/// <param name="titleFormat">The format for the button title, example: "Send to {0}" where "{0}" will be the provider name.</param>
		/// <returns>A string of HTML to cause the sharing API to be rendered.</returns>
		public static MvcHtmlString OneAllSharingDisplayScript(this HtmlHelper helper, OneAllButtonStyle style, bool socialInsights, string titleFormat)
		{
			return OneAllSharingDisplayScript(helper, style, socialInsights, titleFormat, Settings.Instance.ShareUrl);
		}
		#endregion OneAllSharingDisplayScript

		#region OneAllSharingDisplayScript
		/// <summary>Gets the OneAll sharing display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="style">The desired button style.</param>
		/// <param name="socialInsights">True to enable social insights and measure referral traffic.</param>
		/// <param name="titleFormat">The format for the button title, example: "Send to {0}" where "{0}" will be the provider name.</param>
		/// <param name="shareUrl">A custom URL to share, or null to share the URL of the page executing this script.</param>
		/// <returns>A string of HTML to cause the sharing API to be rendered.</returns>
		public static MvcHtmlString OneAllSharingDisplayScript(this HtmlHelper helper, OneAllButtonStyle style, bool socialInsights, string titleFormat, Uri shareUrl)
		{
			return OneAllSharingDisplayScript(helper, style, socialInsights, titleFormat, shareUrl, Settings.Instance.Providers.ToArray());
		}
		#endregion OneAllSharingDisplayScript

		#region OneAllSharingDisplayScript
		/// <summary>Gets the OneAll sharing display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="style">The desired button style.</param>
		/// <param name="socialInsights">True to enable social insights and measure referral traffic.</param>
		/// <param name="titleFormat">The format for the button title, example: "Send to {0}" where "{0}" will be the provider name.</param>
		/// <param name="shareUrl">A custom URL to share, or null to share the URL of the page executing this script.</param>
		/// <param name="providers">The providers to be displayed.</param>
		/// <returns>A string of HTML to cause the sharing API to be rendered.</returns>
		public static MvcHtmlString OneAllSharingDisplayScript(this HtmlHelper helper, OneAllButtonStyle style, bool socialInsights, string titleFormat, Uri shareUrl, params Provider[] providers)
		{
			MvcHtmlString retVal = null;
			if (helper != null) { retVal = MvcHtmlString.Create(ExtensionImplementations.OneAllSharingDisplayScript(style, socialInsights, titleFormat, shareUrl, providers)); }

			return retVal;
		}
		#endregion OneAllSharingDisplayScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, Settings.Instance.DisplayLogOn.Callback.ResolveFullUrl(), true, Settings.Instance.DisplayLogOn.SameWindow,
				Settings.Instance.ProviderNames.ToArray());
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token, Uri callbackUrl)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, Settings.Instance.ProviderNames.ToArray());
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token, params string[] providers)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, Settings.Instance.DisplayLogOn.Callback.ResolveFullUrl(), true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="countHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token, int countHigh, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, Settings.Instance.DisplayLogOn.Width, countHigh,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="countWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token, Uri callbackUrl, int countWide, params string[] providers)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, countWide, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="countWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="countHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token, int countWide, int countHigh, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, countWide, countHigh,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLinkScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="countWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="countHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="theme">The URL for the display style sheet. Use null or empty for the default style.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLinkScript(this HtmlHelper helper, string token, int countWide, int countHigh, string theme, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, true, token, string.Empty, countWide, countHigh, theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLinkScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, Settings.Instance.DisplayLogOn.Callback.ResolveFullUrl(), true, Settings.Instance.DisplayLogOn.SameWindow, Settings.Instance.ProviderNames.ToArray());
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper, Uri callbackUrl)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, Settings.Instance.ProviderNames.ToArray());
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper, params string[] providers)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, Settings.Instance.DisplayLogOn.Callback.ResolveFullUrl(), true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, Settings.Instance.DisplayLogOn.Width, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="countHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper, int countHigh, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, Settings.Instance.DisplayLogOn.Width, countHigh,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="countWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper, Uri callbackUrl, int countWide, params string[] providers)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, countWide, Settings.Instance.DisplayLogOn.Height,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="countWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="countHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper, int countWide, int countHigh, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, countWide, countHigh,
				Settings.Instance.DisplayLogOn.Theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayLogOnScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="countWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="countHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="theme">The URL for the display style sheet. Use null or empty for the default style.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayLogOnScript(this HtmlHelper helper, int countWide, int countHigh, string theme, Uri callbackUrl, params string[] providers)
		{
			return OneAllDisplayScript(helper, false, string.Empty, string.Empty, countWide, countHigh, theme, callbackUrl, true, Settings.Instance.DisplayLogOn.SameWindow, providers);
		}
		#endregion OneAllDisplayLogOnScript

		#region OneAllDisplayScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="link">True if this is a linking script, otherwise false for a login script.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="targetId">The element ID where the display will render. This will be generated if empty.</param>
		/// <param name="countWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="countHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="theme">The URL for the display style sheet. Use null or empty for the default style.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="createTarget">True to create an element with the ID of <paramref name="targetId" />, otherwise false.</param>
		/// <param name="sameWindow">True to conduct the operation in the current window, otherwise false and a new window may be used. The default value is false.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static MvcHtmlString OneAllDisplayScript(this HtmlHelper helper, bool link, string token, string targetId, int countWide, int countHigh, string theme, Uri callbackUrl, bool createTarget, bool sameWindow, params string[] providers)
		{
			MvcHtmlString retVal = null;
			if (helper != null || helper == null) { retVal = MvcHtmlString.Create(ExtensionImplementations.OneAllDisplayScript(link, token, targetId, countWide, countHigh, theme, callbackUrl, createTarget, sameWindow, providers)); }

			return retVal;
		}
		#endregion OneAllDisplayScript

		#region OneAllStandardHeaderScript
		/// <summary>Gets the OneAll header script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <returns>The HTML for the OneAll script intended for the page header.</returns>
		public static MvcHtmlString OneAllHeaderScript(this HtmlHelper helper)
		{
			return helper.OneAllHeaderScript(Settings.Instance.Domain.GetFullUrl(Settings.Instance));
		}
		#endregion OneAllStandardHeaderScript

		#region OneAllStandardHeaderScript
		/// <summary>Gets the OneAll header script for the currently initialized OneAll domain.</summary>
		/// <param name="helper">The standard MVC HTML helper.</param>
		/// <param name="domain">The full OneAll domain value</param>
		/// <returns>The HTML for the OneAll script intended for the page header.</returns>
		public static MvcHtmlString OneAllHeaderScript(this HtmlHelper helper, Uri domain)
		{
			MvcHtmlString retVal = null;
			if (helper != null || helper == null) { retVal = MvcHtmlString.Create(ExtensionImplementations.OneAllHeaderScript(domain)); }

			return retVal;
		}
		#endregion OneAllStandardHeaderScript

		#region OneAllToken
		/// <summary>Get the OneAll token from the <paramref name="request"/> if it exists.</summary>
		/// <param name="request">The <see cref="HttpRequestBase"/> from the current context.</param>
		/// <example>
		/// Example of how to get the connection token after an authentication (log on/link) operation:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid connectionToken = Guid.Empty;
		/// Response<ConnectionDetail> response = null;
		/// 
		/// if (Request.OneAllTokenExists())
		/// {
		///		connectionToken = Request.OneAllToken();
		///		if (!Guid.Empty.Equals(connectionToken))
		///		{
		///			response = OneAllAPI.Default.ConnectionReadDetails(connectionToken);
		///			if (response != null && response.Request != null && response.Request.Status != null &&
		///				response.Request.Status.Code.Equals(200) && response.Connection != null && response.User)
		///				{
		///					// Use the full connection details
		///				}
		///		}
		///		else
		///		{
		///			// Handle (log) the response
		///		}
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="OneAll.Connections.ConnectionDetail"/>
		/// <seealso cref="OneAllAPI.ConnectionReadDetails"/>
		/// <returns>The OneAll token if it exists, or an empty <see cref="Guid"/>.</returns>
		public static Guid OneAllToken(this HttpRequestBase request)
		{
			Guid retVal = Guid.Empty;

			if (request != null)
			{
				try { retVal = new Guid(request[OneAllConstants.HTTP_REQ_CONNECTION_TOKEN]); }
				catch (ArgumentNullException) { retVal = Guid.Empty; }
				catch (OverflowException) { retVal = Guid.Empty; }
				catch (FormatException) { retVal = Guid.Empty; }
			}

			return retVal;
		}
		#endregion OneAllToken

		#region OneAllTokenExists
		/// <summary>Indicates if the request has a OneAll connection token.</summary>
		/// <param name="request">The <see cref="HttpRequestBase"/> from the current context.</param>
		/// <example>
		/// Example of how to get the connection token after an authentication (log on/link) operation:
		/// <code lang="cs">
		/// <![CDATA[
		/// Guid connectionToken = Guid.Empty;
		/// Response<ConnectionDetail> response = null;
		/// 
		/// if (Request.OneAllTokenExists())
		/// {
		///		connectionToken = Request.OneAllToken();
		///		if (!Guid.Empty.Equals(connectionToken))
		///		{
		///			response = OneAllAPI.Default.ConnectionReadDetails(connectionToken);
		///			if (response != null && response.Request != null && response.Request.Status != null &&
		///				response.Request.Status.Code.Equals(200) && response.Connection != null && response.User)
		///				{
		///					// Use the full connection details
		///				}
		///		}
		///		else
		///		{
		///			// Handle (log) the response
		///		}
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="OneAll.Connections.ConnectionDetail"/>
		/// <seealso cref="OneAllAPI.ConnectionReadDetails"/>
		/// <returns>True if the request has a OneAll connection token, otherwise false.</returns>
		public static bool OneAllTokenExists(this HttpRequestBase request)
		{
			return !Guid.Empty.Equals(request.OneAllToken());
		}
		#endregion OneAllTokenExists

		#region OneAllSharingAnalyticsSnapshot
		/// <summary>Reads the snapshot information from the current request.</summary>
		/// <param name="request">The <see cref="HttpRequestBase"/> from the current context.</param>
		/// <example>
		/// Example of how to get a snapshot from a OneAll callback.
		/// <code lang="cs">
		/// <![CDATA[
		/// Response<CompletedSnapshot> responseFull = null;
		/// Response<Snapshot> responseBasic = Request.OneAllSharingAnalyticsSnapshot();
		/// 
		/// if (responseBasic != null && responseBasic.Result != null && responseBasic.Result.Data != null)
		/// {
		///		responseFull = OneAllAPI.Default.SharingAnalyticsGetSnapshot(responseBasic.Result.Data.SnapshotToken);
		///		if (response != null && response.Request != null && response.Request.Status != null &&
		///			response.Request.Status.Code.Equals(200) && response.Result != null && response.Result.Data != null &&
		///			response.Result.Data.Snapshot != null)
		///		{
		///			// Use the full snapshot data
		///		}
		///		else if (response != null && response.Request != null && response.Request.Status != null)
		///		{
		///			// Handle (log) the error
		///		}
		/// }
		/// else if (response != null && response.Request != null && response.Request.Status != null)
		/// {
		///     // Handle (log) the error
		/// }
		/// ]]>
		/// </code>
		/// </example>
		/// <seealso cref="Response"/>
		/// <seealso cref="SnapshotResult"/>
		/// <seealso cref="CompletedSnapshotResult"/>
		/// <seealso cref="Snapshot"/>
		/// <seealso cref="CompletedSnapshot"/>
		/// <seealso cref="OneAllAPI.SharingAnalyticsGetSnapshot"/>
		/// <seealso cref="OneAllAPI.SharingAnalyticsListSnapshots"/>
		/// <seealso cref="OneAllAPI.SharingAnalyticsNewSnapshot"/>
		/// <seealso cref="OneAllAPI.SharingAnalyticsDeleteSnapshot"/>
		/// <remarks>This method should only be used in the context of a OneAll callback URL from a snapshot creation.</remarks>
		/// <returns>A <see cref="Response&lt;SnapshotResult&gt;"/> representing the basic information required to obtain the completed snapshot.</returns>
		public static Response<SnapshotResult> OneAllSharingAnalyticsSnapshot(this HttpRequestBase request)
		{
			Response<SnapshotResult> retVal = null;
			if (request != null && request.InputStream != null && request.InputStream.CanRead)
			{
				string json = string.Empty;
				using (StreamReader reader = new StreamReader(request.InputStream))
				{
					json = reader.ReadToEnd();
				}

				if (!string.IsNullOrEmpty(json))
				{
					retVal = retVal.FromJson(json);
				}
			}
			return retVal;
		}
		#endregion OneAllSharingAnalyticsSnapshot

		#endregion Methods
	}
}