using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrelloPublisher : MonoBehaviour {

	private static readonly string[] TRELLO_POSITIONS = { "top", "bottom" };

	private const string TRELLO_BASE_URL = "https://api.trello.com/1";
	private const string CARD_BASE_URL = TRELLO_BASE_URL + "/cards/";
	private const string CARD_UPLOAD_ERROR = "Could not post new card to Trello: ";

	// Learn how to get authentication here: https://developers.trello.com/page/authorization
	[SerializeField]
	private string key = "EX: 1efc3f63f89141e6fc65e08539a61c53";
	[SerializeField]
	private string token = "EX: 47fbe4360b3b81990bd12ca5efe35e1e3a468a6e6b2046e78081817a2797bcea";
	[SerializeField]
	private string[] lists = { "LIST_1", "LIST_2" };

	[SerializeField]
	private GameObject trelloCanvas;
	[SerializeField]
	private GameObject reportPanel;
	[SerializeField]
	private InputField cardName;
	[SerializeField]
	private InputField cardDesc;
	[SerializeField]
	private Dropdown cardPosition;
	[SerializeField]
	private Dropdown cardList;

	public void PostCard() {
		StartCoroutine(PostNewCard(new TrelloCard(cardName.text, cardDesc.text, TRELLO_POSITIONS[cardPosition.value], lists[cardList.value])));
	}

	private IEnumerator PostNewCard(TrelloCard card) {
		WWW connection = new WWW(CARD_BASE_URL + "?" + "key=" + key + "&token=" + token, card.GetPostBody());
		yield return connection;
		CheckConnectionStatus(CARD_UPLOAD_ERROR, connection);
	}

	private void CheckConnectionStatus(string errorMessage, WWW www) {
		if (!string.IsNullOrEmpty(www.error)) {
			Debug.LogError(errorMessage + www.error);
		}
	}

	public void Reset() {
		cardName.text = "";
		cardDesc.text = "";
		reportPanel.SetActive(false);
	}

}
