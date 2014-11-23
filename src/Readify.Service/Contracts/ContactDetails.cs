using System.Runtime.Serialization;
namespace knockknock.readify.net
{		
	[DataContract]
	public partial class ContactDetails : object, System.Runtime.Serialization.IExtensibleDataObject
	{

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private string EmailAddressField;

		private string FamilyNameField;

		private string GivenNameField;

		private string PhoneNumberField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataField;
			}
			set
			{
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string EmailAddress
		{
			get
			{
				return this.EmailAddressField;
			}
			set
			{
				this.EmailAddressField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string FamilyName
		{
			get
			{
				return this.FamilyNameField;
			}
			set
			{
				this.FamilyNameField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string GivenName
		{
			get
			{
				return this.GivenNameField;
			}
			set
			{
				this.GivenNameField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string PhoneNumber
		{
			get
			{
				return this.PhoneNumberField;
			}
			set
			{
				this.PhoneNumberField = value;
			}
		}
	}
}