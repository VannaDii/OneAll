using System;

namespace OneAll
{
	/// <summary>Static and constant value used within the OneAll .Net API.</summary>
	public static class OneAllConstants
	{
		#region Member Variables

		/// <summary>The literal string value "OneAll".</summary>
		internal const string CONFIG_SECTION_NAME = "OneAll";

		/// <summary>The method name "ValidateUriSecure".</summary>
		internal const string CONFIG_VALIDATOR_SECUREURI = "ValidateUriSecure";

		/// <summary>The literal value "Basic".</summary>
		internal const string CRED_BASIC = "Basic";

		/// <summary>The literal string "The configured domain is invalid."</summary>
		internal const string ERR_INVALID_DOMAIN = "The configured domain is invalid.";

		/// <summary>The literal value "Invalid HTTP method specified."</summary>
		internal const string ERR_INVALID_HTTP_METHOD = "Invalid HTTP method specified.";

		/// <summary>The literal value "Parameter cannot be null or empty."</summary>
		internal const string ERR_INVALID_PARAM = "Parameter cannot be null or empty.";

		/// <summary>The literal string "Parameter cannot be null or empty and cannot contain empty elements."</summary>
		internal const string ERR_INVALID_PARAM_COLLECTION = "Parameter cannot be null or empty and cannot contain empty elements.";

		/// <summary>The literal string "The value specified is not a secure URL."</summary>
		internal const string ERR_UNSECURE_URI = "The value specified is not a secure URL.";

		/// <summary>The literal value "N".</summary>
		internal const string FORMAT_GUID = "N";

		/// <summary>The literal value "oneallcdn.com/css/api/socialize/themes/buildin/{0}/large-v1.css".</summary>
		internal const string FORMAT_ONEALL_CDN_URL = "oneallcdn.com/css/api/socialize/themes/buildin/{0}/large-v1.css";

		/// <summary>The literal value "&lt;div id=\"{0}\"&gt;&lt;/div&gt;".</summary>
		internal const string FORMAT_TARGET_ELEM = "<div id=\"{0}\"></div>";

		/// <summary>The literal value "XPG-OneAll (Version: {0})"</summary>
		internal const string FORMAT_USER_AGENT = "XPG-OneAll (Version: {0})";

		/// <summary>The literal value "Authorization".</summary>
		internal const string HEAD_AUTHORIZATION = "Authorization";

		/// <summary>The literal value "Basic {0}".</summary>
		internal const string HEAD_BASIC = "Basic {0}";

		/// <summary>The literal value "{0}:{1}".</summary>
		internal const string HEAD_BASIC_CRED = "{0}:{1}";

		/// <summary>The HTTP Content-Type "application/x-www-form-urlencoded".</summary>
		internal const string HTTP_CONTENTTYPE_FORMURLENCODE = "application/x-www-form-urlencoded";

		/// <summary>The literal value "connection_token".</summary>
		internal const string HTTP_REQ_CONNECTION_TOKEN = "connection_token";

		/// <summary>The literal value "+".</summary>
		internal const string INVALID_TIMESPAN_VALUE = "+";

		/// <summary>The literal value "\", \"".</summary>
		internal const string JOIN_SEP_QUOTE_COMMA = "\", \"";

		/// <summary>The literal value "&lt;/script&gt;".</summary>
		internal const string JS_CLOSE = "</script>";

		/// <summary>The header script formatter with one position {0} for domain.</summary>
		internal static string JS_HEADER_STANDARD_FORMAT = "<script type=\"text/javascript\">" + Environment.NewLine +
							"\tvar oneall_js_protocol = ((\"https:\" == document.location.protocol) ? \"https\" : \"http\");" + Environment.NewLine +
							"\tdocument.write(unescape(\"%3Cscript src='\"+oneall_js_protocol+\"://{0}" + //domain.DnsSafeHost +
							"/socialize/library.js' type='text/javascript'%3E%3C/script%3E\"));" + Environment.NewLine +
							"</script>";

		/// <summary>The literal value "&lt;!--// Begin OneAll Code //--&gt;".</summary>
		internal const string JS_MARK_BEGIN = "<!--// Begin OneAll Code //-->";

		/// <summary>The literal value "&lt;!--// End OneAll Code //--&gt;".</summary>
		internal const string JS_MARK_END = "<!--// End OneAll Code //-->";

		/// <summary>The literal value "&lt;script type=\"text/javascript\"&gt;".</summary>
		internal const string JS_OPEN = "<script type=\"text/javascript\">";

		/// <summary>The literal value "});".</summary>
		internal const string JS_PLUGIN_CALL_CLOSE = "});";

		/// <summary>The literal value "oneall.api.plugins.social_{1}.build(\"{0}\", {{".</summary>
		internal const string JS_PLUGIN_CALL_OPEN = "oneall.api.plugins.social_{1}.build(\"{0}\", {{";

		/// <summary>The literal value "\tcallback_uri:  \"{0}\"".</summary>
		internal const string JS_PLUGIN_PARAM_CALLBACK_URI = "\tcallback_uri:  \"{0}\"";

		/// <summary>The literal value "\tcss_theme_uri: oneall_js_protocol + \"://{0}\",".</summary>
		internal const string JS_PLUGIN_PARAM_CSS_THEME_URL = "\tcss_theme_uri: oneall_js_protocol + \"://{0}\",";

		/// <summary>The literal value "\tgrid_size_x: \"{0}\",".</summary>
		internal const string JS_PLUGIN_PARAM_GRID_SIZE_X = "\tgrid_size_x: \"{0}\",";

		/// <summary>The literal value "\tgrid_size_y: \"{0}\",".</summary>
		internal const string JS_PLUGIN_PARAM_GRID_SIZE_Y = "\tgrid_size_y: \"{0}\",";

		/// <summary>The literal value "\tproviders: [\"{0}\"],".</summary>
		internal const string JS_PLUGIN_PARAM_PROVIDERS = "\tproviders: [\"{0}\"],";

		/// <summary>The literal value "\tsame_window: true,".</summary>
		internal const string JS_PLUGIN_PARAM_SAME_WINDOW = "\tsame_window: true,";

		/// <summary>The literal value "user_token: \"{0}\",".</summary>
		internal const string JS_PLUGIN_PARAM_USER_TOKEN = "user_token: \"{0}\",";

		/// <summary>The literal value "callbackUrl".</summary>
		internal const string PARAM_CALLBACK_URL = "callbackUrl";

		/// <summary>The parameter value pair "confirm_deletion=true".</summary>
		internal const string PARAM_CONFIRM_DELETION = "confirm_deletion=true";

		/// <summary>The literal value "method".</summary>
		internal const string PARAM_METHOD = "method";

		/// <summary>The literal value "providers".</summary>
		internal const string PARAM_PROVIDERS = "providers";

		/// <summary>The literal value "link".</summary>
		internal const string PLUGIN_MODE_LINK = "link";

		/// <summary>The literal value "login".</summary>
		internal const string PLUGIN_MODE_LOGIN = "login";

		/// <summary>The literal value "Connect".</summary>
		public const string PlugInThemeConnect = "Connect";

		/// <summary>The literal value "Signin".</summary>
		public const string PlugInThemeSignIn = "Signin";

		/// <summary>The literal value "Signup".</summary>
		public const string PlugInThemeSignup = "Signup";

		/// <summary>The format of an RFC 2822 date time value.</summary>
		internal const string RFC_2822_DATETIME_FORMAT = "ddd, dd MMM yyyy HH:mm:ss K";

		/// <summary>The partial URL "/connections" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_CONNECTION_LISTALL = "/connections" + URL_DATA_EXTENSION + "";

		/// <summary>The extension used in every URL which determines the data type/format of the response (JSON or XML).</summary>
		internal const string URL_DATA_EXTENSION = ".json";

		/// <summary>The partial URL "/connections/{0:D}" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_FORMAT_CONNECTION_DETAIL = "/connections/{0:D}" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/sharing/messages/{0:D}" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_FORMAT_SHARING = "/sharing/messages/{0:D}" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/sharing/analytics/snapshots/{0:D}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION.</summary>
		internal const string URL_FORMAT_SHARING_ANALYTICS_DELETE = "/sharing/analytics/snapshots/{0:D}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION;

		/// <summary>The partial URL "/sharing/analytics/snapshots/{0:D}" + URL_DATA_EXTENSION.</summary>
		internal const string URL_FORMAT_SHARING_ANALYTICS_DETAILS = "/sharing/analytics/snapshots/{0:D}" + URL_DATA_EXTENSION;

		/// <summary>The partial URL "/sharing/analytics/snapshots" + URL_DATA_EXTENSION.</summary>
		internal const string URL_FORMAT_SHARING_ANALYTICS_INITIATE = "/sharing/analytics/snapshots" + URL_DATA_EXTENSION;

		/// <summary>The partial URL "/sharing/analytics/snapshots" + URL_DATA_EXTENSION.</summary>
		internal const string URL_FORMAT_SHARING_ANALYTICS_LIST = "/sharing/analytics/snapshots" + URL_DATA_EXTENSION;

		/// <summary>The partial URL "/sharing/messages/{0:D}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION.</summary>
		internal const string URL_FORMAT_SHARING_DELETE = "/sharing/messages/{0:D}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION;

		/// <summary>The partial URL "/shorturls/{0}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION.</summary>
		internal const string URL_FORMAT_SHORTENED_URL_DELETE = "/shorturls/{0}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION;

		/// <summary>The partial URL "/shorturls/{0}" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_FORMAT_SHORTENED_URL_DETAIL = "/shorturls/{0}" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/users/{0:D}/contacts" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_FORMAT_USER_CONTACTS = "/users/{0:D}/contacts" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/users/{0:D}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION.</summary>
		internal const string URL_FORMAT_USER_DELETE = "/users/{0:D}" + URL_DATA_EXTENSION + "?" + PARAM_CONFIRM_DELETION;

		/// <summary>The partial URL "/users/{0:D}" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_FORMAT_USER_DETAIL = "/users/{0:D}" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/users/{0:D}/publish" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_FORMAT_USER_PUBLISH = "/users/{0:D}/publish" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/sharing/messages" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_SHARING = "/sharing/messages" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/shorturls" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_SHORTENED_URL_CREATE_LIST = "/shorturls" + URL_DATA_EXTENSION + "";

		/// <summary>The partial URL "/users" + URL_DATA_EXTENSION + "".</summary>
		internal const string URL_USER_LISTALL = "/users" + URL_DATA_EXTENSION + "";

		#endregion Member Variables
	}
}