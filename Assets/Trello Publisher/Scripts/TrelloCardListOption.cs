using UnityEngine;

namespace Trello {

	[System.Serializable]
	public class TrelloCardListOption {

		[SerializeField]
		private string name;
		[SerializeField]
		private string id;

		public string Name {
			get {
				return name;
			}
		}

		public string Id {
			get {
				return id;
			}
		}

	}

}

