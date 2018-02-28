using UnityEngine;
using System.Collections;

namespace Trello {

	[CreateAssetMenu(fileName = "New Trello Publisher", menuName = "Trello Publisher", order = 10001)]
	public class TrelloPublisher : ScriptableObject {

		private const string TRELLO_BASE_URL = "https://api.trello.com/1";
		private const string CARD_BASE_URL = TRELLO_BASE_URL + "/cards/";
		private const string CARD_UPLOAD_ERROR = "Could not upload new card to Trello: ";

		[SerializeField]
		private string key;
		[SerializeField]
		private string token;
		[SerializeField]
		private TrelloCardListOption[] trelloCardListOptions;

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

	}

}
