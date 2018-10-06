using UnityEngine;

namespace Trello
{
	[System.Serializable]
	public class TrelloCardOption
	{
		[SerializeField]
		private string name;
		[SerializeField]
		private string id;

		public TrelloCardOption(string name, string id)
		{
			this.name = name;
			this.id = id;
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public string Id
		{
			get
			{
				return id;
			}
		}
	}
}
