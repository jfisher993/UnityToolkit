using UnityEngine;
using System.Collections;

namespace Trello {

	[CreateAssetMenu(fileName = "New Trello Poster", menuName = "Trello Poster", order = 10001)]
	public class TrelloPoster : ScriptableObject {

		private const string TRELLO_BASE_URL = "https://api.trello.com/1";
		private const string CARD_BASE_URL = TRELLO_BASE_URL + "/cards/";
		private const string CARD_UPLOAD_ERROR = "Could not upload new card to Trello: ";

		[SerializeField]
		private string key = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
		[SerializeField]
		private string token = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
		[SerializeField]
		private string boardId = "XXXXXXXXXXXXXXXXXXXXXXXX";
		[SerializeField]
		private TrelloCardListOption[] trelloCardListOptions = new TrelloCardListOption[1] { new TrelloCardListOption("Card List Name", "XXXXXXXXXXXXXXXXXXXXXXXX") };

		public IEnumerator PostCard(TrelloCard card) {
			WWW connection = new WWW(CARD_BASE_URL + "?" + "key=" + key + "&token=" + token, card.GetPostBody());
			yield return connection;
			CheckConnectionStatus(CARD_UPLOAD_ERROR, connection);
		}

		private void CheckConnectionStatus(string errorMessage, WWW connection) {
			if (!string.IsNullOrEmpty(connection.error)) {
				Debug.LogError(errorMessage + connection.error);
			}
		}

		public TrelloCardListOption[] TrelloCardListOptions {
			get {
				return trelloCardListOptions;
			}
		}

		public string Key {
			get {
				return key;
			}
		}

		public string Token {
			get {
				return token;
			}
		}

		public string BoardId {
			get {
				return boardId;
			}
		}

	}

}
