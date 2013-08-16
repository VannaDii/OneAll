using System;

namespace OneAll
{
	#region Delegates

	#region BinaryReceivedHandler
	/// <summary>Invoked after a request for data is completed.</summary>
	/// <param name="data">An <see cref="Byte" /> array or null.</param>
	/// <param name="state">The originally specified state object.</param>
	/// <param name="error">The error, if any.</param>
	internal delegate void BinaryReceivedHandler(byte[] data, object state, Exception error);
	#endregion BinaryReceivedHandler

	#endregion Delegates
}