using UnityEngine;

namespace MailChimp {

	[System.Serializable]
	public class MailChimpUser {

		[SerializeField]
		private string emailAddress;
		[SerializeField]
		private string firstName;
		[SerializeField]
		private string lastName;

		public MailChimpUser(string emailAddress, string firstName = "", string lastName = "") {
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

		public override string ToString() {
			return "Email Address=" + emailAddress + "\nFirst Name=" + firstName + "\nLast Name=" + lastName;
		}

	}

}
