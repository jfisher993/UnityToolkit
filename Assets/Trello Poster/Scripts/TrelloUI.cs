using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Trello;

public class TrelloUI : MonoBehaviour
{
	private static readonly string[] TrelloCardPositions = { "top", "bottom" };

	[SerializeField]
	private TrelloPoster trelloPoster;
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
	[SerializeField]
	private Dropdown cardLabel;
	[SerializeField]
	private Toggle includeScreenshot;

	private Texture2D screenshot;
	private bool noLabels = false;

	private void Start()
	{
		cardList.AddOptions(GetDropdownOptions(trelloPoster.TrelloCardListOptions));
		TrelloCardOption[] cardLabels = trelloPoster.TrelloCardLabelOptions;
		if (cardLabels == null || cardLabels.Length == 0)
		{
			noLabels = true;
			cardLabel.gameObject.SetActive(false);
		}
		else
		{
			cardLabel.AddOptions(GetDropdownOptions(cardLabels));
		}
	}

	public void StartPostCard()
	{
		StartCoroutine(trelloPoster.PostCard(new TrelloCard(cardName.text, cardDesc.text, TrelloCardPositions[cardPosition.value], trelloPoster.TrelloCardListOptions[cardList.value].Id, noLabels ? null : trelloPoster.TrelloCardLabelOptions[cardLabel.value].Id, includeScreenshot.isOn ? screenshot.EncodeToPNG() : null)));
	}

	private List<Dropdown.OptionData> GetDropdownOptions(TrelloCardOption[] cardOptions)
	{
		List<Dropdown.OptionData> dropdownOptions = new List<Dropdown.OptionData>();
		for (int i = 0; i < cardOptions.Length; i++)
		{
			dropdownOptions.Add(new Dropdown.OptionData(cardOptions[i].Name));
		}
		return dropdownOptions;
	}

	public void ToggleCanvas()
	{
		trelloCanvas.SetActive(!trelloCanvas.activeSelf);
	}

	public void ToggleCanvas(bool isEnabled)
	{
		trelloCanvas.SetActive(isEnabled);
	}

	public void TogglePanel()
	{
		reportPanel.SetActive(!reportPanel.activeSelf);
	}

	public void TakeScreenshot()
	{
		screenshot = ScreenCapture.CaptureScreenshotAsTexture();
	}

	public void ResetUI()
	{
		cardName.text = "";
		cardDesc.text = "";
	}
}
