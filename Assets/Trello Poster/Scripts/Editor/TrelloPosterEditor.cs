using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Trello
{
	[CustomEditor(typeof(TrelloPoster))]
	public class TrelloPosterEditor : Editor
	{
		private const string HexRegex = @"[0-9]|[a-f]";
		private const int KeyLength = 32;
		private const int TokenLength = 64;
		private const int BoardCardLabelIdLength = 24;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			TrelloPoster trelloPoster = (TrelloPoster) target;
			string key = trelloPoster.Key;
			string token = trelloPoster.Token;
			string boardId = trelloPoster.BoardId;

			if (GUILayout.Button("Get Key"))
			{
				Application.OpenURL("https://trello.com/app-key");
			}

			EditorGUI.BeginDisabledGroup(IsInvalid(key, KeyLength));

			if (GUILayout.Button("Get Token"))
			{
				Application.OpenURL("https://trello.com/1/authorize?key=" + key + "&scope=read%2Cwrite&expiration=never&response_type=token");
			}

			EditorGUI.BeginDisabledGroup(IsInvalid(token, TokenLength));

			if (GUILayout.Button("Get Board Id's"))
			{
				Application.OpenURL("https://api.trello.com/1/members/me/boards?key=" + key + "&token=" + token);
			}

			EditorGUI.BeginDisabledGroup(IsInvalid(boardId, BoardCardLabelIdLength));

			if (GUILayout.Button("Get Card List Id's"))
			{
				Application.OpenURL("https://api.trello.com/1/boards/" + boardId + "/lists?key=" + key + "&token=" + token);
			}

			if (GUILayout.Button("Get Card Label Id's"))
			{
				Application.OpenURL("https://api.trello.com/1/boards/" + boardId + "?labels=all&key=" + key + "&token=" + token);
			}

			EditorGUI.BeginDisabledGroup(trelloPoster.TrelloCardListOptions.Length == 0 || IsTrelloOptionInvalid(trelloPoster.TrelloCardListOptions) || IsTrelloOptionInvalid(trelloPoster.TrelloCardLabelOptions));

			if (GUILayout.Button("Post Test Cards"))
			{
				for (int i = 0; i < trelloPoster.TrelloCardListOptions.Length; i++)
				{
					TrelloCardOption cardList = trelloPoster.TrelloCardListOptions[i];

					TrelloCardOption[] cardLabels = trelloPoster.TrelloCardLabelOptions;
					string cardLabelId = cardLabels == null || i >= cardLabels.Length ? null : cardLabels[i].Id;

					Debug.Log("Attempting to post card to list " + cardList.Name);

					IEnumerator postCard = trelloPoster.PostCard(new TrelloCard("Trello Poster Test - " + cardList.Name, "Thanks for using Trello Poster!\n[View Source](https://github.com/jfisher993/UnityToolkit/tree/master/Assets/Trello%20Poster)", "top", cardList.Id, cardLabelId, null));
					while (postCard.MoveNext())
						;
				}
				Debug.Log("Check your Trello Board to see if new cards were posted!");
			}

			EditorGUI.EndDisabledGroup();
		}

		private bool IsTrelloOptionInvalid(TrelloCardOption[] trelloOption)
		{
			for (int i = 0; i < trelloOption.Length; i++)
			{
				if (IsInvalid(trelloOption[i].Id, BoardCardLabelIdLength))
				{
					return true;
				}
			}
			return false;
		}

		private bool IsInvalid(string field, int length)
		{
			return field.Length != length || !Regex.IsMatch(field, HexRegex);
		}
	}
}
