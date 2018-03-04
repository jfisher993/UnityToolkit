using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace MailChimp {

	[CreateAssetMenu(fileName = "New MailChimp Subscriber", menuName = "MailChimp Subscriber", order = 10002)]
	public class MailChimpSubscriber : ScriptableObject {

		private const string SIGN_UP_ERROR = "Could not subscribe user to MailChimp List: ";

		[SerializeField]
		private string formUrl;
		[SerializeField]
		private string formKey;

		public IEnumerator Subscribe(MailChimpUser mailChimpUser) {
			WWWForm form = mailChimpUser.AsForm();
			form.AddField(formKey, "");
			UnityWebRequest webRequest = UnityWebRequest.Post(formUrl, form);
			webRequest.chunkedTransfer = false;
			yield return webRequest.SendWebRequest();
			CheckWebRequestStatusAndDispose(webRequest, mailChimpUser, SIGN_UP_ERROR);
		}

		private void CheckWebRequestStatusAndDispose(UnityWebRequest webRequest, MailChimpUser mailChimpUser, string errorMessage = "Web Request Error: ") {
			if (!string.IsNullOrEmpty(webRequest.error)) {
				Debug.LogError(errorMessage + "\n" + mailChimpUser.ToString() + webRequest.downloadHandler.text);
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
