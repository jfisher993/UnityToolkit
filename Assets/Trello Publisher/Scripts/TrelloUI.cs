using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Trello;

public class TrelloUI : MonoBehaviour {

	private static readonly string[] TRELLO_POSITIONS = { "top", "bottom" };

	[SerializeField]
	private TrelloPublisher trelloPublisher;
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

	private void Start() {
		SetCardListOptionData();
	}

	public void StartPostCard() {
		StartCoroutine(trelloPublisher.PostCard(new TrelloCard(cardName.text, cardDesc.text, TRELLO_POSITIONS[cardPosition.value], trelloPublisher.TrelloCardListOptions[cardList.value].Id)));
	}

	private void SetCardListOptionData() {
		List<Dropdown.OptionData> cardListOptions = new List<Dropdown.OptionData>();
		for (int i = 0; i < trelloPublisher.TrelloCardListOptions.Length; i++) {
			cardListOptions.Add(new Dropdown.OptionData(trelloPublisher.TrelloCardListOptions[i].Name));
		}
		cardList.AddOptions(cardListOptions);
	}

	public void ToggleCanvas() {
		trelloCanvas.SetActive(!trelloCanvas.activeSelf);
	}

	public void TogglePanel() {
		reportPanel.SetActive(!reportPanel.activeSelf);
		ResetUI();
	}

	private void ResetUI() {
		cardName.text = "";
		cardDesc.text = "";
	}

}

