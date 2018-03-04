using UnityEngine;

namespace Mailchimp {

	[System.Serializable]
	public class MailchimpUser {

		[SerializeField]
		private string emailAddress;
		[SerializeField]
		private string firstName;
		[SerializeField]
		private string lastName;

		public MailchimpUser(string emailAddress, string firstName = "", string lastName = "") {
			this.emailAddress = emailAddress;
			this.firstName = firstName;
			this.lastName = lastName;
		}

		public WWWForm AsForm() {
			WWWForm form = new WWWForm();
			form.AddField("EMAIL", emailAddress);
			form.AddField("FNAME", firstName);
			form.AddField("LNAME", lastName);
			return form;
		}

	}

}
