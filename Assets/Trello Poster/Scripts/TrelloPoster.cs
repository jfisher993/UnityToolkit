﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Trello
{
	[CreateAssetMenu(fileName = "New Trello Poster", menuName = "Trello Poster", order = 10001)]
	public class TrelloPoster : ScriptableObject
	{
		private const string TrelloBaseUrl = "https://api.trello.com/1";
		private const string CardBaseUrl = TrelloBaseUrl + "/cards/";
		private const string CardUploadError = "Could not upload new card to Trello: ";

		[SerializeField]
		private string key = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
		[SerializeField]
		private string token = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
		[SerializeField]
		private string boardId = "XXXXXXXXXXXXXXXXXXXXXXXX";
		[SerializeField]
		private TrelloCardOption[] cardLists = new TrelloCardOption[1] { new TrelloCardOption("Card List Name", "XXXXXXXXXXXXXXXXXXXXXXXX") };
		[SerializeField]
		private TrelloCardOption[] cardLabels = new TrelloCardOption[1] { new TrelloCardOption("Card Label Name", "XXXXXXXXXXXXXXXXXXXXXXXX") };

		public IEnumerator PostCard(TrelloCard card)
		{
			WWWForm postBody = card.GetPostBody();
			UnityWebRequest webRequest = UnityWebRequest.Post(CardBaseUrl + "?" + "key=" + key + "&token=" + token, postBody);
			webRequest.chunkedTransfer = false;
			yield return webRequest.SendWebRequest();
			CheckWebRequestStatusAndDispose(webRequest, CardUploadError);
		}

		private void CheckWebRequestStatusAndDispose(UnityWebRequest webRequest, string errorMessage = "Web Request Error: ")
		{
			if (!string.IsNullOrEmpty(webRequest.error))
			{
				Debug.LogError(errorMessage + webRequest.downloadHandler.text);
			}
			webRequest.Dispose();
		}

		public string Key
		{
			get
			{
				return key;
			}
		}

		public string Token
		{
			get
			{
				return token;
			}
		}

		public string BoardId
		{
			get
			{
				return boardId;
			}
		}

		public TrelloCardOption[] TrelloCardListOptions
		{
			get
			{
				return cardLists;
			}
		}

		public TrelloCardOption[] TrelloCardLabelOptions
		{
			get
			{
				return cardLabels;
			}
		}
	}
}
