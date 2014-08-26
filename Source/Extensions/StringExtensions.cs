using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using OneAll.Config;
using System.Security;
using System.Runtime.InteropServices;

namespace OneAll
{
    /// <summary>Extension methods for strings used in this assembly.</summary>
    public static class StringExtensions
    {
        #region Methods

        #region GetFullUrl
        /// <summary>Gets the full URL from a possible partial URL.</summary>
        /// <param name="url">The full or partial URL.</param>
        /// <param name="settings">The <see cref="Settings"/> for the current context.</param>
        /// <returns>A string o the full URL.</returns>
        internal static Uri GetFullUrl(this Uri url, Settings settings)
        {
            return new Uri(settings.Domain, url);
        }
        #endregion GetFullUrl

        #region FormatSafe
        /// <summary>Prepares a string for safe use in a formatter.</summary>
        /// <param name="value">The original value.</param>
        /// <returns>A formatter escaped version.</returns>
        internal static string FormatSafe(this string value)
        {
            return value.Replace("{", "{{").Replace("}", "}}");
        }
        #endregion FormatSafe

        #region DateTimeFromRFC2822
        /// <summary>Attempts to read a <see cref="DateTime" /> from an RFC 2822 formatted date and time string.</summary>
        /// <param name="value">The RFC 2822 date time string value.</param>
        /// <returns>A <see cref="DateTime" /> representing the <paramref name="value" /> or the current date and time in UTC.</returns>
        internal static DateTime DateTimeFromRFC2822(this string value)
        {
            DateTime retVal = DateTime.UtcNow;
            string dateInternal = string.Empty;

            if (!string.IsNullOrEmpty(value) && value.Length > 5)
            {
                dateInternal = (value[value.Length - 5].Equals(' ') ? value.Insert(value.Length - 4, "+") : value);
                if (!DateTime.TryParseExact(dateInternal, OneAllConstants.RFC_2822_DATETIME_FORMAT, null, DateTimeStyles.AllowWhiteSpaces, out retVal))
                    return retVal = DateTime.UtcNow;
            }

            return retVal;
        }
        #endregion DateTimeFromRFC2822

        #region DateTimeToRFC2822
        /// <summary>Attempts to read a <see cref="DateTime" /> from an RFC 2822 formatted date and time string.</summary>
        /// <param name="value">The RFC 2822 date time string value.</param>
        /// <returns>A <see cref="DateTime" /> representing the <paramref name="value" /> or the current date and time in UTC.</returns>
        internal static string DateTimeToRFC2822(this DateTime value)
        {
            return value.ToString(OneAllConstants.RFC_2822_DATETIME_FORMAT, CultureInfo.InvariantCulture);
        }
        #endregion DateTimeToRFC2822

        #region ToUnsecureString
        /// <summary>Converts a secure string to an unsecure string.</summary>
        /// <param name="secureString">The secured string to convert.</param>
        /// <returns>An unsecured string containing the value of the secured string.</returns>
        internal static string ToUnsecureString(this SecureString secureString)
        {
            if (secureString == null)
                throw new ArgumentNullException("secureString");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        #endregion ToUnsecureString

        #region ToTimeSpan
        /// <summary>Attempts to parse a <see cref="String"/> into a <see cref="TimeSpan"/>.</summary>
        /// <param name="value">The time span string value.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the <paramref name="value"/> or the minimum allowed value.</returns>
        internal static TimeSpan ToTimeSpan(this string value)
        {
            TimeSpan retVal = TimeSpan.MinValue;
            if (!string.IsNullOrEmpty(value))
            {
                string valueInternal = value.StartsWith(OneAllConstants.INVALID_TIMESPAN_VALUE, StringComparison.OrdinalIgnoreCase) ? value.Substring(1) : value;
                if (!TimeSpan.TryParse(valueInternal, out retVal)) { retVal = TimeSpan.MinValue; }
            }
            return retVal;
        }
        #endregion ToTimeSpan

        #region FromJson
        /// <summary>Reads an instance type object from JSON data.</summary>
        /// <typeparam name="T">The type of the object to read.</typeparam>
        /// <param name="instance">The instance to use for the type.</param>
        /// <param name="json">The JSON data to read.</param>
        /// <returns>An instance of the type from JSON data.</returns>
        public static T FromJson<T>(this T instance, string json) where T : class
        {
            T retVal = null;
            byte[] data = null;
            object objTemp = null;
            JSONSurrogate sur = null;
            string jsonInternal = string.Empty;
            DataContractJsonSerializer dcjs = null;

            try
            {
                if (!string.IsNullOrEmpty(json) && instance == null)
                {
                    // Prep and strip standard wrapper
                    jsonInternal = json.Trim();
                    jsonInternal = jsonInternal.Substring(jsonInternal.IndexOf('{', 1));
                    jsonInternal = jsonInternal.Substring(0, jsonInternal.LastIndexOf('}'));

                    data = Encoding.UTF8.GetBytes(jsonInternal);
                    if (data != null && data.Length > 0)
                    {
                        jsonInternal = null;
                        sur = new JSONSurrogate();
                        dcjs = new DataContractJsonSerializer(typeof(T), "root", null, int.MaxValue, true, sur, false);

                        MemoryStream ms = new MemoryStream();
                        try
                        {
                            ms.Write(data, 0, data.Length);
                            ms.Seek(0, SeekOrigin.Begin);

                            objTemp = dcjs.ReadObject(ms);
                        }
                        finally { ms.Dispose(); }

                        retVal = objTemp as T;
                    }
                }
            }
            finally
            {
                sur = null;
                if (data != null)
                {
                    Array.Clear(data, 0, data.Length);
                    data = null;
                }
            }

            return retVal;
        }
        #endregion FromJson

        #region ToJson
        /// <summary>Reads an instance of an object to JSON data.</summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <param name="instance">The instance from which the type is derived.</param>
        /// <returns>JSON string of data for the instance.</returns>
        internal static string ToJson<T>(this T instance) where T : class
        {
            string retVal = string.Empty;
            StreamReader reader = null;
            MemoryStream stream = null;
            DataContractAttribute[] dca = null;
            DataContractJsonSerializer json = null;

            try
            {
                stream = new MemoryStream();
                reader = new StreamReader(stream);
                json = new DataContractJsonSerializer(typeof(T));
                json.WriteObject(stream, instance);

                stream.Seek(0, SeekOrigin.Begin);
                retVal = reader.ReadToEnd();

                if (!string.IsNullOrEmpty(retVal))
                {
                    // Strip extra MS string formatting
                    retVal = Regex.Replace(retVal, "\\\\(.)", "$1", RegexOptions.IgnoreCase | RegexOptions.Multiline);

                    // Add standard wrapper
                    dca = typeof(T).GetCustomAttributes(typeof(DataContractAttribute), false) as DataContractAttribute[];
                    if (dca != null && dca.Length > 0)
                    {
                        retVal = string.Format(CultureInfo.InvariantCulture, "{{\"{0}\":{1}}}", dca[0].Name, retVal);
                    }
                }
            }
            catch
            {
                retVal = string.Empty;
                throw;
            }
            finally
            {
                if (reader != null) reader.Close();
                else if (stream != null) stream.Close();
            }

            return retVal;
        }
        #endregion ToJson

        #endregion Methods
    }
}