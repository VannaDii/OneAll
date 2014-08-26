using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace OneAll
{
	/// <summary>A data contract surrogate for OneAll API data.</summary>
	internal class JSONSurrogate : IDataContractSurrogate
	{
		#region Methods

		#region GetCustomDataToExport
		/// <summary>During schema export operations, inserts annotations into the schema for non-null return values.</summary>
		/// <param name="clrType">The CLR type to be replaced.</param>
		/// <param name="dataContractType">The data contract type to be annotated.</param>
		/// <returns>An object that represents the annotation to be inserted into the XML schema definition.</returns>
		public object GetCustomDataToExport(Type clrType, Type dataContractType)
		{
			return null;
		}
		#endregion GetCustomDataToExport

		#region GetCustomDataToExport
		/// <summary>During schema export operations, inserts annotations into the schema for non-null return values.</summary>
		/// <param name="memberInfo">A <see cref="MemberInfo"/> that describes the member.</param>
		/// <param name="dataContractType">A <see cref="Type"/>.</param>
		/// <returns>An object that represents the annotation to be inserted into the XML schema definition.</returns>
		public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
		{
			return null;
		}
		#endregion GetCustomDataToExport

		#region GetDataContractType
		/// <summary>During serialization, deserialization, and schema import and export, returns a data contract type that substitutes the specified type.</summary>
		/// <param name="type">The CLR type System.Type to substitute.</param>
		/// <returns>The <see cref="Type"/> to substitute for the type value. This type must be serializable by the <see cref="DataContractSerializer"/>. For example, it must be marked with the <see cref="DataContractAttribute"/> attribute or other mechanisms that the serializer recognizes.</returns>
		public Type GetDataContractType(Type type)
		{
			return type;
		}
		#endregion GetDataContractType

		#region GetDeserializedObject
		/// <summary>During deserialization, returns an object that is a substitute for the specified object.</summary>
		/// <param name="obj">The deserialized object to be substituted.</param>
		/// <param name="targetType">The <see cref="Type"/> that the substituted object should be assigned to.</param>
		/// <returns>The substituted deserialized object. This object must be of a type that is serializable by the <see cref="DataContractSerializer"/>. For example, it must be marked with the <see cref="DataContractAttribute"/> attribute or other mechanisms that the serializer recognizes.</returns>
		public object GetDeserializedObject(object obj, Type targetType)
		{
			return obj;
		}
		#endregion GetDeserializedObject

		#region GetKnownCustomDataTypes
		/// <summary>Sets the collection of known types to use for serialization and deserialization of the custom data objects.</summary>
		/// <param name="customDataTypes">A <see cref="Collection&lt;T&gt;"/> of <see cref="Type"/> to add known types to.</param>
		public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
		{
		}
		#endregion GetKnownCustomDataTypes

		#region GetObjectToSerialize
		/// <summary>During serialization, returns an object that substitutes the specified object.</summary>
		/// <param name="obj">The object to substitute.</param>
		/// <param name="targetType">The <see cref="Type"/> that the substituted object should be assigned to.</param>
		/// <returns>The substituted object that will be serialized. The object must be serializable by the <see cref="DataContractSerializer"/>. For example, it must be marked with the <see cref="DataContractAttribute"/> attribute or other mechanisms that the serializer recognizes.</returns>
		public object GetObjectToSerialize(object obj, Type targetType)
		{
			return obj;
		}
		#endregion GetObjectToSerialize

		#region GetReferencedTypeOnImport
		/// <summary>During schema import, returns the type referenced by the schema.</summary>
		/// <param name="typeName">The name of the type in schema.</param>
		/// <param name="typeNamespace">The namespace of the type in schema.</param>
		/// <param name="customData">The object that represents the annotation inserted into the XML schema definition, which is data that can be used for finding the referenced type.</param>
		/// <returns>The <see cref="Type"/> to use for the referenced type.</returns>
		public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
		{
			return null;
		}
		#endregion GetReferencedTypeOnImport

		#region ProcessImportedType
		/// <summary>Processes the type that has been generated from the imported schema.</summary>
		/// <param name="typeDeclaration">A <see cref="CodeTypeDeclaration"/> to process that represents the type declaration generated during schema import.</param>
		/// <param name="compileUnit">The <see cref="CodeCompileUnit"/> that contains the other code generated during schema import.</param>
		/// <returns>A <see cref="CodeTypeDeclaration"/> that contains the processed type.</returns>
		public System.CodeDom.CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
		{
			return typeDeclaration;
		}
		#endregion ProcessImportedType

		#endregion Methods
	}
}