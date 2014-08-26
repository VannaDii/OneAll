using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A base class for all OneAll object collections.</summary>
	/// <typeparam name="T">The type of <see cref="BaseObject"/> object used in the collection.</typeparam>
	[CollectionDataContract()]
	public class BaseCollection<T> : ObservableCollection<T>
		where T : INotifyPropertyChanged
	{
		#region Events

		#region PropertyChanged
		/// <summary>Raised when a property of this object has been changed.</summary>
		new public event PropertyChangedEventHandler PropertyChanged;
		#endregion PropertyChanged

		#endregion Events

		#region Methods

		#region OnPropertyChanged
		/// <summary>Raises the PropertyChanged event for a named property of this object.</summary>
		/// <param name="name">The name of the property for which the value has been changed.</param>
		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (null != handler) { handler(this, new PropertyChangedEventArgs(name)); }
		}
		#endregion OnPropertyChanged

		#endregion Methods
	}
}
