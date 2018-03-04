using UnityEngine;
using UnityEditor;

namespace Mailchimp {

	[CustomEditor(typeof(MailchimpSubscriber))]
	public class MailchimpSubscriberEditor : Editor {

		private const string TEST_EMAIL_ADDRESS = "test@testemail.com";
		private const string TEST_FIRST_NAME = "First";
		private const string TEST_LAST_NAME = "Last";

		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			MailchimpSubscriber mailchimpSubscriber = (MailchimpSubscriber) target;

			EditorGUI.BeginDisabledGroup(!Application.isPlaying || string.IsNullOrEmpty(mailchimpSubscriber.FormURL) || string.IsNullOrEmpty(mailchimpSubscriber.FormKey));

			if (GUILayout.Button("Test Subscribe")) {
				Debug.Log("Subscribing: " + TEST_EMAIL_ADDRESS);
				FindObjectOfType<MailchimpUI>().StartMailchimpSubscribe(new MailchimpUser(TEST_EMAIL_ADDRESS, TEST_FIRST_NAME, TEST_LAST_NAME));
				Debug.Log("Check your Mailchimp List to see if " + TEST_EMAIL_ADDRESS + " was subscribed!");
			}

			EditorGUI.EndDisabledGroup();

			if (GUILayout.Button("Visit Mailchimp")) {
				Application.OpenURL("https://mailchimp.com/");
			}
		}

	}

}
