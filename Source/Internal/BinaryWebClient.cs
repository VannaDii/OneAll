using System;
using System.IO;
using System.Net;

namespace OneAll
{
	/// <summary>A static utility class for obtaining data from remote sources.</summary>
	internal static class BinaryWebClient
	{
		#region Methods

		#region Get
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="url">The URL for the request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="callBack">The call-back to invoke after the request is complete, if null this method is synchronous.</param>
		/// <param name="state">The state information, ignored if callBack is null.</param>
		internal static byte[] Get(Uri url, OneAllMethod method, Credential creds, BinaryReceivedHandler callBack, object state)
		{
			byte[] retVal = null;

			if (callBack == null) { retVal = GetSync(url, method, creds); }
			else { GetAsync(url, method, creds, callBack, state); }

			return retVal;
		}
		#endregion Get

		#region Post
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="url">The URL for the request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="data">The raw data to be posted.</param>
		/// <param name="callBack">The call-back to invoke after the request is complete, if null this method is synchronous.</param>
		/// <param name="state">The state information, ignored if callBack is null.</param>
		internal static byte[] Post(Uri url, OneAllMethod method, Credential creds, byte[] data, BinaryReceivedHandler callBack, object state)
		{
			byte[] retVal = null;

			if (callBack == null) { retVal = PostSync(url, method, creds, data); }
			else { PostAsync(url, method, creds, data, callBack, state); }

			return retVal;
		}
		#endregion Post

		#region GetAsync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="url">The URL for the request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="callBack">The call-back to invoke after the request is complete.</param>
		/// <param name="state">The state information.</param>
		private static void GetAsync(Uri url, OneAllMethod method, Credential creds, BinaryReceivedHandler callBack, object state)
		{
			GetAsync(HttpWebRequest.Create(url) as HttpWebRequest, method, creds, callBack, state);
		}
		#endregion GetAsync

		#region GetAsync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="request">The HTTP web request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="callBack">The call-back to invoke after the request is complete.</param>
		/// <param name="state">The initial state object provided.</param>
		private static void GetAsync(HttpWebRequest request, OneAllMethod method, Credential creds, BinaryReceivedHandler callBack, object state)
		{
			request.SetHTTPMethod(method);
			request.SetBasicAuth(creds);
			request.BeginGetResponse(OnRequestCompleted, new BinaryWebClientState()
			{
				Request = request,
				Callback = callBack,
				State = state
			});
		}
		#endregion GetAsync

		#region GetSync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="url">The URL for the request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <returns>The binary data from the request.</returns>
		private static byte[] GetSync(Uri url, OneAllMethod method, Credential creds)
		{
			return GetSync(HttpWebRequest.Create(url) as HttpWebRequest, method, creds);
		}
		#endregion GetSync

		#region GetSync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="request">The HTTP web request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <returns>The binary data from the request.</returns>
		private static byte[] GetSync(HttpWebRequest request, OneAllMethod method, Credential creds)
		{
			request.SetHTTPMethod(method);
			request.SetBasicAuth(creds);
			return ReadResponse(request);
		}
		#endregion GetSync

		#region OnRequestCompleted
		/// <summary>Invoked when a request is completed.</summary>
		/// <param name="state">The asynchronous state.</param>
		private static void OnRequestCompleted(IAsyncResult state)
		{
			byte[] data = null;
			Exception error = null;
			BinaryWebClientState bwcs = state.AsyncState as BinaryWebClientState;

			if (bwcs.Request != null)
			{
				try { data = ReadResponse(bwcs.Request); }
				catch (WebException e) { error = e; }
			}

			if (bwcs.Callback != null)
			{
				bwcs.Callback(data, bwcs.State, error);
			}
		}
		#endregion OnRequestCompleted

		#region OnRequestStreamObtained
		/// <summary>Invoked when a request is completed.</summary>
		/// <param name="state">The asynchronous state.</param>
		private static void OnRequestStreamObtained(IAsyncResult state)
		{
			BinaryWebClientState bwcs = state.AsyncState as BinaryWebClientState;
			if (bwcs.Request != null)
			{
				using (Stream stream = bwcs.Request.EndGetRequestStream(state))
				{
					byte[] buffer = new byte[bwcs.Data.Length];
					Array.Copy(bwcs.Data, buffer, buffer.Length);

					stream.Write(buffer, 0, buffer.Length);
					stream.Flush();

					Array.Clear(buffer, 0, buffer.Length);
					buffer = null;
				}

				bwcs.Request.BeginGetResponse(OnRequestCompleted, bwcs);
			}
		}
		#endregion OnRequestStreamObtained

		#region PostAsync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="url">The URL for the request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="data">The raw data to be posted.</param>
		/// <param name="callBack">The call-back to invoke after the request is complete.</param>
		/// <param name="state">The state information.</param>
		private static void PostAsync(Uri url, OneAllMethod method, Credential creds, byte[] data, BinaryReceivedHandler callBack, object state)
		{
			PostAsync(HttpWebRequest.Create(url) as HttpWebRequest, method, creds, data, callBack, state);
		}
		#endregion PostAsync

		#region PostAsync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="request">The HTTP web request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="data">The raw data to be posted.</param>
		/// <param name="callBack">The call-back to invoke after the request is complete.</param>
		/// <param name="state">The initial state object provided.</param>
		private static void PostAsync(HttpWebRequest request, OneAllMethod method, Credential creds, byte[] data, BinaryReceivedHandler callBack, object state)
		{
			request.ContentType = OneAllConstants.HTTP_CONTENTTYPE_FORMURLENCODE;
			request.SetHTTPMethod(method);
			request.SetBasicAuth(creds);

			request.BeginGetRequestStream(OnRequestStreamObtained, new BinaryWebClientState()
			{
				Request = request,
				Callback = callBack,
				State = state,
				Data = data
			});
		}
		#endregion PostAsync

		#region PostSync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="url">The URL for the request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="data">The raw data to be posted.</param>
		/// <returns>The binary data from the request.</returns>
		private static byte[] PostSync(Uri url, OneAllMethod method, Credential creds, byte[] data)
		{
			return PostSync(HttpWebRequest.Create(url) as HttpWebRequest, method, creds, data);
		}
		#endregion PostSync

		#region PostSync
		/// <summary>Attempts to get data from a web request.</summary>
		/// <param name="request">The HTTP web request.</param>
		/// <param name="method">The OneAll supported HTTP method to use.</param>
		/// <param name="creds">The <see cref="Credential"/> used to authenticate the call, or null for calls not requiring authentication.</param>
		/// <param name="data">The raw data to be posted.</param>
		/// <returns>The binary data from the request.</returns>
		private static byte[] PostSync(HttpWebRequest request, OneAllMethod method, Credential creds, byte[] data)
		{
			request.ContentType = OneAllConstants.HTTP_CONTENTTYPE_FORMURLENCODE;
			request.SetHTTPMethod(method);
			request.SetBasicAuth(creds);

			using (Stream stream = request.GetRequestStream())
			{
				byte[] buffer = new byte[data.Length];
				Array.Copy(data, buffer, buffer.Length);

				stream.Write(buffer, 0, buffer.Length);
				stream.Flush();

				Array.Clear(buffer, 0, buffer.Length);
				buffer = null;
			}

			return ReadResponse(request);
		}
		#endregion PostSync

		#region ReadResponse
		/// <summary>Reads data from a response to a request.</summary>
		/// <param name="request">The request.</param>
		/// <returns>The data read.</returns>
		private static byte[] ReadResponse(HttpWebRequest request)
		{
			byte[] data = null;

			try
			{
				using (WebResponse response = request.GetResponse())
				{
					data = ReadResponseData(response as HttpWebResponse);
				}
			}
			catch (WebException wex)
			{
				data = ReadResponseData(wex.Response);
			}

			return data;
		}
		#endregion ReadResponse

		#region ReadResponseData
		/// <summary>Reads the data from a response.</summary>
		/// <param name="response">The response.</param>
		private static byte[] ReadResponseData(WebResponse response)
		{
			int count = 0;
			byte[] data = null;

			if (response != null)
			{
				data = new byte[4096];
				using (Stream stream = response.GetResponseStream())
				{
					using (MemoryStream mem = new MemoryStream())
					{
						do
						{
							count = stream.Read(data, 0, data.Length);
							mem.Write(data, 0, count);
						}
						while (count > 0);

						data = new byte[mem.Length];
						mem.Seek(0, SeekOrigin.Begin);
						mem.Read(data, 0, data.Length);
					}
				}
			}

			return data;
		}
		#endregion ReadResponseData

		#endregion Methods
	}
}