using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Mailchimp {

	[CreateAssetMenu(fileName = "New Mailchimp Subscriber", menuName = "Mailchimp Subscriber", order = 10002)]
	public class MailchimpSubscriber : ScriptableObject {

		private const string SIGN_UP_ERROR = "Could not sign up new subscriber to Mailchimp List: ";

		[SerializeField]
		private string formUrl;
		[SerializeField]
		private string formKey;

		public IEnumerator Subscribe(MailchimpUser mailchimpUser) {
			WWWForm form = mailchimpUser.AsForm();
			form.AddField(formKey, "");
			UnityWebRequest webRequest = UnityWebRequest.Post(formUrl, form);
			webRequest.chunkedTransfer = false;
			yield return webRequest.SendWebRequest();
			CheckWebRequestStatusAndDispose(webRequest, SIGN_UP_ERROR);
		}

		private void CheckWebRequestStatusAndDispose(UnityWebRequest webRequest, string errorMessage = "Web Request Error: ") {
			if (!string.IsNullOrEmpty(webRequest.error)) {
				Debug.LogError(errorMessage + webRequest.downloadHandler.text);
			}
			webRequest.Dispose();
		}

		public string FormURL {
			get {
				return formUrl;
			}
		}

		public string FormKey {
			get {
				return formKey;
			}
		}

	}

}
