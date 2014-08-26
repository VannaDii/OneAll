using System.Collections.Generic;
using System.Configuration;

namespace OneAll.Config
{
	/// <summary>A collection of OneAll providers.</summary>
	public sealed class ProviderConfigElementCollection : ConfigurationElementCollection, ICollection<ProviderConfigElement>
	{
		#region Properties

		#region CollectionType
		/// <summary>Gets the type of the <see cref="ConfigurationElementCollection" />.</summary>
		public override ConfigurationElementCollectionType CollectionType { get { return ConfigurationElementCollectionType.BasicMapAlternate; } }
		#endregion CollectionType

		#region ElementName
		/// <summary>Gets the name used to identify this collection of elements in the configuration file when overridden in a derived class.</summary>
		protected override string ElementName { get { return "Provider"; } }
		#endregion ElementName

		#region ThrowOnDuplicate
		/// <summary>Gets a value indicating whether an attempt to add a duplicate <see cref="ConfigurationElement" /> to the <see cref="ConfigurationElementCollection" /> will cause an exception to be thrown.</summary>
		protected override bool ThrowOnDuplicate { get { return true; } }
		#endregion ThrowOnDuplicate

		internal IEnumerable<string> AllNames() { if (this.Count > 0) { foreach (ProviderConfigElement pce in this) { yield return pce.Name; } } else { yield return string.Empty; } }

		internal IEnumerable<string> AllDisplayNames() { if (this.Count > 0) { foreach (ProviderConfigElement pce in this) { yield return pce.DisplayName; } } else { yield return string.Empty; } }

		internal IEnumerable<Provider> AllProviders() { foreach (ProviderConfigElement pce in this) { yield return new Provider() { Identifier = pce.Name, Name = pce.DisplayName }; } }

		#endregion Properties

		#region Methods

		#region CreateNewElement
		/// <summary>When overridden in a derived class, creates a new <see cref="ConfigurationElement" />.</summary>
		/// <returns>Returns a new instance of a <see cref="ConfigurationElement" />.</returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new ProviderConfigElement();
		}
		#endregion CreateNewElement

		#region GetElementKey
		/// <summary>Gets the element key for a specified configuration element when overridden in a derived class.</summary>
		/// <param name="element">The <see cref="ConfigurationElement" /> to return the key for.</param>
		/// <returns>An <see cref="System.Object" /> that acts as the key for the specified <see cref="ConfigurationElement" />.</returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			object retVal = null;
			ProviderConfigElement provider = element as ProviderConfigElement;
			if (provider != null) { retVal = provider.Name; }
			return retVal;
		}
		#endregion GetElementKey

		#endregion Methods

		void ICollection<ProviderConfigElement>.Add(ProviderConfigElement item)
		{
			BaseAdd(item);
		}

		void ICollection<ProviderConfigElement>.Clear()
		{
			BaseClear();
		}

		bool ICollection<ProviderConfigElement>.Contains(ProviderConfigElement item)
		{
			return (BaseIndexOf(item) != -1);
		}

		void ICollection<ProviderConfigElement>.CopyTo(ProviderConfigElement[] array, int arrayIndex)
		{
			array = new ProviderConfigElement[base.Count];
			for (int i = 0; i < Count; i++)
				array[i] = BaseGet(i) as ProviderConfigElement;
		}

		int ICollection<ProviderConfigElement>.Count
		{
			get { return base.Count; }
		}

		bool ICollection<ProviderConfigElement>.IsReadOnly
		{
			get { return base.IsReadOnly(); }
		}

		bool ICollection<ProviderConfigElement>.Remove(ProviderConfigElement item)
		{
			if (item != null) BaseRemove(item.Name);
			return true;
		}

		IEnumerator<ProviderConfigElement> IEnumerable<ProviderConfigElement>.GetEnumerator()
		{
			List<ProviderConfigElement> list = new List<ProviderConfigElement>();
			foreach (ProviderConfigElement elem in this)
				list.Add(elem);

			return list.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return base.GetEnumerator();
		}
	}
}