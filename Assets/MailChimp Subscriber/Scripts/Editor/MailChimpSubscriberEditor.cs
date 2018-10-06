using UnityEngine;
using UnityEditor;

namespace MailChimp
{
	[CustomEditor(typeof(MailChimpSubscriber))]
	public class MailChimpSubscriberEditor : Editor
	{
		private const string TestEmailAddress = "test@testemail.com";
		private const string TestFirstName = "First";
		private const string TestLastName = "Last";

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			MailChimpSubscriber mailChimpSubscriber = (MailChimpSubscriber) target;

			EditorGUI.BeginDisabledGroup(!Application.isPlaying || string.IsNullOrEmpty(mailChimpSubscriber.FormURL) || string.IsNullOrEmpty(mailChimpSubscriber.FormKey));

			if (GUILayout.Button("Test Subscribe"))
			{
				Debug.Log("Subscribing: " + TestEmailAddress);
				FindObjectOfType<MailChimpUI>().StartMailChimpSubscribe(new MailChimpUser(TestEmailAddress, TestFirstName, TestLastName));
				Debug.Log("Check your MailChimp List to see if " + TestEmailAddress + " was subscribed!");
			}

			EditorGUI.EndDisabledGroup();

			if (GUILayout.Button("Visit MailChimp"))
			{
				Application.OpenURL("https://mailchimp.com/");
			}
		}
	}
}
