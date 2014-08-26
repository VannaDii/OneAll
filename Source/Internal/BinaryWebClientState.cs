using System.Net;

namespace OneAll
{
	/// <summary>Represents the state of an Binary request.</summary>
	internal class BinaryWebClientState
	{
		#region Properties

		#region Callback
		/// <summary>The call-back to invoke after the Binary is obtained.</summary>
		internal BinaryReceivedHandler Callback { get; set; }
		#endregion Callback

		#region Request
		/// <summary>The associated request.</summary>
		internal HttpWebRequest Request { get; set; }
		#endregion Request

		#region State
		/// <summary>The context state.</summary>
		internal object State { get; set; }
		#endregion State

		#region Data
		/// <summary>The raw data to be streamed to the server.</summary>
		internal byte[] Data { get; set; }
		#endregion Data

		#endregion Properties
	}
}