using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using Trello;
using System.Collections;

[CustomEditor(typeof(TrelloPoster))]
public class TrelloPosterEditor : Editor {

	private const string HEX_REGEX = @"[0-9]|[a-f]";
	private const int KEY_LENGTH = 32;
	private const int TOKEN_LENGTH = 64;
	private const int BOARD_AND_CARD_ID_LENGTH = 24;

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		TrelloPoster trelloPoster = (TrelloPoster) target;
		string key = trelloPoster.Key;
		string token = trelloPoster.Token;
		string boardId = trelloPoster.BoardId;

		if (GUILayout.Button("Get Key")) {
			Application.OpenURL("https://trello.com/app-key");
		}

		EditorGUI.BeginDisabledGroup(IsInvalid(key, KEY_LENGTH));

		if (GUILayout.Button("Get Token")) {
			Application.OpenURL("https://trello.com/1/authorize?key=" + key + "&scope=read%2Cwrite&expiration=never&response_type=token");
		}

		EditorGUI.BeginDisabledGroup(IsInvalid(token, TOKEN_LENGTH));

		if (GUILayout.Button("Get Board Id's")) {
			Application.OpenURL("https://api.trello.com/1/members/me/boards?key=" + key + "&token=" + token);
		}

		EditorGUI.BeginDisabledGroup(IsInvalid(boardId, BOARD_AND_CARD_ID_LENGTH));

		if (GUILayout.Button("Get Card List Id's")) {
			Application.OpenURL("https://api.trello.com/1/boards/" + boardId + "/lists?key=" + key + "&token=" + token);
		}

		for (int i = 0; i < trelloPoster.TrelloCardListOptions.Length; i++) {
			bool isInvalid = IsInvalid(trelloPoster.TrelloCardListOptions[i].Id, BOARD_AND_CARD_ID_LENGTH);
			if (isInvalid) {
				EditorGUI.BeginDisabledGroup(true);
				break;
			}
		}

		if (GUILayout.Button("Publish Test Cards")) {
			for (int i = 0; i < trelloPoster.TrelloCardListOptions.Length; i++) {
				string cardListName = trelloPoster.TrelloCardListOptions[i].Name;
				Debug.Log("Attempting to post card to list " + cardListName);
				IEnumerator postCard = trelloPoster.PostCard(new TrelloCard("Trello Poster Test - " + cardListName, "Thanks for using Trello Poster!\nSource: https://github.com/jfisher993/UnityToolkit/tree/master/Assets/Trello%20Poster", "top", trelloPoster.TrelloCardListOptions[i].Id));
				while (postCard.MoveNext());
			}
			Debug.Log("Check your Trello Board to see if new cards were posted!");
		}

		EditorGUI.EndDisabledGroup();
	}

	private bool IsInvalid(string field, int length) {
		return field.Length != length || !Regex.IsMatch(field, HEX_REGEX);
	}

}
