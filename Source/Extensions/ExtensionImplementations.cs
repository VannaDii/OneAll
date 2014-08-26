using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OneAll
{
	/// <summary>Extension method implementation logic.</summary>
	internal static class ExtensionImplementations
	{
		#region IsThemeName
		/// <summary>Indicates if the value is a known OneAll theme.</summary>
		/// <param name="value">The value.</param>
		/// <returns>True if it's a known theme, otherwise false</returns>
		private static bool IsThemeName(string value)
		{
			return (value.Equals(OneAllConstants.PlugInThemeSignIn, StringComparison.OrdinalIgnoreCase) ||
				value.Equals(OneAllConstants.PlugInThemeSignup, StringComparison.OrdinalIgnoreCase) ||
				value.Equals(OneAllConstants.PlugInThemeConnect, StringComparison.OrdinalIgnoreCase));
		}
		#endregion IsThemeName

		#region OneAllDisplayScript
		/// <summary>Gets the OneAll login display script for the currently initialized OneAll domain.</summary>
		/// <param name="link">True if this is a linking script, otherwise false for a login script.</param>
		/// <param name="token">A user token, or null, or empty.</param>
		/// <param name="targetId">The element ID where the display will render. This will be generated if empty.</param>
		/// <param name="numWide">The maximum number of providers to display horizontally. Any value less than 1 will equal unconstrained.</param>
		/// <param name="numHigh">The maximum number of providers to display vertically. Any value less than 1 will equal unconstrained.</param>
		/// <param name="cssUrl">The URL for the display style sheet. Use null or empty for the default style.</param>
		/// <param name="callbackUrl">The URL the OneAll API calls back to with results. This cannot be null or empty.</param>
		/// <param name="createTarget">True to create an element with the ID of <paramref name="targetId" />, otherwise false.</param>
		/// <param name="sameWindow">True to conduct the operation in the current window, otherwise false and a new window may be used. The default value is false.</param>
		/// <param name="providers">A list of the providers to the displayed. This cannot be null or empty and cannot contain empty elements.</param>
		/// <returns>The HTML for the OneAll script intended for displaying the options.</returns>
		public static string OneAllDisplayScript(bool link, string token, string targetId, int numWide, int numHigh, string cssUrl, Uri callbackUrl, bool createTarget, bool sameWindow, params string[] providers)
		{
			string retVal = null;
			string cssUrlInternal = cssUrl;
			string targetIdInternal = targetId;
			string mode = (link ? OneAllConstants.PLUGIN_MODE_LINK : OneAllConstants.PLUGIN_MODE_LOGIN);
			StringBuilder builder = new StringBuilder();
			bool createTargetInternal = (string.IsNullOrEmpty(targetId) || createTarget);

			try
			{
				if (callbackUrl == null) throw new ArgumentException(OneAllConstants.ERR_INVALID_PARAM, OneAllConstants.PARAM_CALLBACK_URL);
				if (providers == null || providers.Length < 1 || providers.All(x => string.IsNullOrEmpty(x)))
					throw new ArgumentException(OneAllConstants.ERR_INVALID_PARAM_COLLECTION, OneAllConstants.PARAM_PROVIDERS);

				if (string.IsNullOrEmpty(targetIdInternal)) targetIdInternal = Guid.NewGuid().ToString(OneAllConstants.FORMAT_GUID);
				if (!string.IsNullOrEmpty(cssUrlInternal) && IsThemeName(cssUrlInternal))
					cssUrlInternal = string.Format(CultureInfo.InvariantCulture, OneAllConstants.FORMAT_ONEALL_CDN_URL, cssUrlInternal.FormatSafe());
				if (!string.IsNullOrEmpty(cssUrlInternal) && cssUrlInternal.Contains(Uri.SchemeDelimiter))
					cssUrlInternal = cssUrlInternal.Substring(cssUrlInternal.IndexOf(Uri.SchemeDelimiter, StringComparison.OrdinalIgnoreCase) + Uri.SchemeDelimiter.Length);

				builder.AppendLine(OneAllConstants.JS_MARK_BEGIN);
				if (createTargetInternal) builder.AppendFormat(OneAllConstants.FORMAT_TARGET_ELEM + Environment.NewLine, targetIdInternal.FormatSafe());
				builder.AppendLine(OneAllConstants.JS_OPEN);
				builder.AppendFormat(OneAllConstants.JS_PLUGIN_CALL_OPEN, targetIdInternal.FormatSafe(), mode);
				builder.AppendFormat(OneAllConstants.JS_PLUGIN_PARAM_PROVIDERS + Environment.NewLine, string.Join(OneAllConstants.JOIN_SEP_QUOTE_COMMA, providers).FormatSafe());
				if (sameWindow) builder.AppendLine(OneAllConstants.JS_PLUGIN_PARAM_SAME_WINDOW);
				if (!string.IsNullOrEmpty(cssUrlInternal)) builder.AppendFormat(OneAllConstants.JS_PLUGIN_PARAM_CSS_THEME_URL + Environment.NewLine, cssUrlInternal.FormatSafe());
				if (numWide > 0) builder.AppendFormat(OneAllConstants.JS_PLUGIN_PARAM_GRID_SIZE_X + Environment.NewLine, numWide);
				if (numHigh > 0) builder.AppendFormat(OneAllConstants.JS_PLUGIN_PARAM_GRID_SIZE_Y + Environment.NewLine, numHigh);
				if (!string.IsNullOrEmpty(token)) builder.AppendFormat(OneAllConstants.JS_PLUGIN_PARAM_USER_TOKEN + Environment.NewLine, token.FormatSafe());
				builder.AppendFormat(OneAllConstants.JS_PLUGIN_PARAM_CALLBACK_URI + Environment.NewLine, callbackUrl.ToString().FormatSafe());
				builder.AppendLine(OneAllConstants.JS_PLUGIN_CALL_CLOSE);
				builder.AppendLine(OneAllConstants.JS_CLOSE);
				builder.AppendLine(OneAllConstants.JS_MARK_END);

				retVal = builder.ToString();
			}
			catch { throw; }

			return retVal;
		}
		#endregion OneAllDisplayScript

		#region OneAllHeaderScript
		/// <summary>Gets the OneAll standard header script for the currently initialized OneAll domain.</summary>
		/// <param name="domain">The full OneAll domain value</param>
		/// <returns>The HTML for the OneAll standard script intended for the page header.</returns>
		public static string OneAllHeaderScript(Uri domain)
		{
			string retVal = null;

			try { retVal = string.Format(CultureInfo.InvariantCulture, OneAllConstants.JS_HEADER_STANDARD_FORMAT, domain.DnsSafeHost); }
			catch { throw new ConfigurationErrorsException(OneAllConstants.ERR_INVALID_DOMAIN); }

			return retVal;
		}
		#endregion OneAllHeaderScript

		#region OneAllSharingDisplayScript
		/// <summary>Gets the OneAll social sharing display script.</summary>
		/// <param name="style">The desired button style.</param>
		/// <param name="socialInsights">True to enable social insights and measure referral traffic.</param>
		/// <param name="titleFormat">The format for the button title, example: "Send to {0}" where "{0}" will be the provider name.</param>
		/// <param name="shareUrl">A custom URL to share, or null to share the URL of the page executing this script.</param>
		/// <param name="providers">The providers to be displayed.</param>
		/// <returns>A string of HTML to cause the sharing API to be rendered.</returns>
		public static string OneAllSharingDisplayScript(OneAllButtonStyle style, bool socialInsights, string titleFormat, Uri shareUrl, params Provider[] providers)
		{
			if (providers == null || providers.Length < 1 || providers.All(x => string.IsNullOrEmpty(x.Identifier)))
				throw new ArgumentException(OneAllConstants.ERR_INVALID_PARAM_COLLECTION, OneAllConstants.PARAM_PROVIDERS);

			string retVal = null;
			string styleInternal = string.Empty;
			string dataUrl = string.Empty, dataOpt = string.Empty;
			StringBuilder builder = new StringBuilder();

			switch (style)
			{
				case OneAllButtonStyle.Small: { styleInternal = "oas_box_btns_s"; } break;
				case OneAllButtonStyle.Medium: { styleInternal = "oas_box_btns_m"; } break;
				case OneAllButtonStyle.Large: { styleInternal = "oas_box_btns_l"; } break;
				case OneAllButtonStyle.HorizontalCounter: { styleInternal = "oas_box_count_h"; } break;
				case OneAllButtonStyle.VerticalCounter: { styleInternal = "oas_box_count_v"; } break;
				default: { styleInternal = "oas_box_btns_s"; } break;
			}

			dataUrl = (shareUrl != null ? " data-url=\"" + shareUrl.ToString() + "\"" : string.Empty);
			dataOpt = (!socialInsights ? " data-opt=\"si:0\"" : string.Empty);

			builder.AppendLine(string.Format(CultureInfo.InvariantCulture, "<div class=\"oas_box {0}\"{1}{2}>", styleInternal, dataUrl, dataOpt));
			foreach (Provider provider in providers)
			{
				if (string.IsNullOrEmpty(provider.Identifier)) { continue; }
				else
				{
					builder.AppendLine(string.Format(CultureInfo.InvariantCulture, "\t<span class=\"oas_btn oas_btn_{0}\" title=\"{1}\"></span>", provider.Identifier,
						(!string.IsNullOrEmpty(titleFormat) && titleFormat.Contains("{0}") && !string.IsNullOrEmpty(provider.Name) ?
							string.Format(CultureInfo.InvariantCulture, titleFormat, provider.Name) : string.Empty)));
				}
			}
			builder.Append("</div>");

			if (builder != null)
				retVal = builder.ToString();

			return retVal;
		}
		#endregion OneAllSharingDisplayScript
	}
}