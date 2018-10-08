using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Trello
{
	[CreateAssetMenu(fileName = "New Trello Poster", menuName = "Trello Poster", order = 10001)]
	public class TrelloPoster : ScriptableObject
	{
		private const string TrelloBaseUrl = "https://api.trello.com/1";
		private const string CardBaseUrl = TrelloBaseUrl + "/cards/";
		private const string CardUploadError = "Could not upload new card to Trello: ";
		private const string CardAttachmentError = "Could not add attachment to Trello card: ";

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

		public string LastCardId { get; private set; }

		public IEnumerator PostCard(TrelloCard card)
		{
			WWWForm postBody = card.GetPostBody();
			UnityWebRequest webRequest = BuildAuthenticatedWebRequest(CardBaseUrl, postBody);
			yield return webRequest.SendWebRequest();
			CheckWebRequestStatusAndDispose(webRequest, CardUploadError);
		}

		public IEnumerator AddAttachment(string cardId, byte[] attachment, string attachmentName)
		{
			WWWForm postBody = new WWWForm();
			postBody.AddField("name", attachmentName);
			postBody.AddBinaryData("file", attachment, attachmentName);
			postBody.AddField("mimeType", "text/plain");
			UnityWebRequest webRequest = BuildAuthenticatedWebRequest(CardBaseUrl + cardId + "/attachments/", postBody);
			yield return webRequest.SendWebRequest();
			CheckWebRequestStatusAndDispose(webRequest, CardAttachmentError);
		}

		private UnityWebRequest BuildAuthenticatedWebRequest(string baseUrl, WWWForm postBody)
		{
			UnityWebRequest webRequest = UnityWebRequest.Post(baseUrl + "?" + "key=" + key + "&token=" + token, postBody);
			webRequest.chunkedTransfer = false;
			return webRequest;
		}

		private void CheckWebRequestStatusAndDispose(UnityWebRequest webRequest, string errorMessage = "Web Request Error: ")
		{
			if (string.IsNullOrEmpty(webRequest.error))
			{
				LastCardId = JsonUtility.FromJson<TrelloCardResponse>(webRequest.downloadHandler.text).id;
			}
			else
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

		public class TrelloCardResponse
		{
			public string id;
		}
	}
}
