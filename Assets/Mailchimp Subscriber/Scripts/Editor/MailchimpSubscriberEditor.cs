using UnityEngine;
using UnityEditor;

namespace MailChimp {

	[CustomEditor(typeof(MailChimpSubscriber))]
	public class MailChimpSubscriberEditor : Editor {

		private const string TEST_EMAIL_ADDRESS = "test@testemail.com";
		private const string TEST_FIRST_NAME = "First";
		private const string TEST_LAST_NAME = "Last";

		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			MailChimpSubscriber mailChimpSubscriber = (MailChimpSubscriber) target;

			EditorGUI.BeginDisabledGroup(!Application.isPlaying || string.IsNullOrEmpty(mailChimpSubscriber.FormURL) || string.IsNullOrEmpty(mailChimpSubscriber.FormKey));

			if (GUILayout.Button("Test Subscribe")) {
				Debug.Log("Subscribing: " + TEST_EMAIL_ADDRESS);
				FindObjectOfType<MailChimpUI>().StartMailChimpSubscribe(new MailChimpUser(TEST_EMAIL_ADDRESS, TEST_FIRST_NAME, TEST_LAST_NAME));
				Debug.Log("Check your MailChimp List to see if " + TEST_EMAIL_ADDRESS + " was subscribed!");
			}

			EditorGUI.EndDisabledGroup();

			if (GUILayout.Button("Visit MailChimp")) {
				Application.OpenURL("https://mailchimp.com/");
			}
		}

	}

}
