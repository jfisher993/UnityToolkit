using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Text.RegularExpressions;
using MailChimp;

public class MailChimpUI : MonoBehaviour
{
	private const string EmailAddressRegex = @".{1,}[@].{1,}[.].{1,}";
	private const string InvalidEmailAddress = "<color=red>Invalid Email Address!</color>";
	private const string SubscribeSuccess = "<color=green>Thank you for Subscribing!</color>";
	private const int SubscribeTimeout = 15;

	[SerializeField]
	private MailChimpSubscriber mailChimpSubscriber;
	[SerializeField]
	private GameObject subscribeCanvas;
	[SerializeField]
	private GameObject subscribePanel;
	[SerializeField]
	private InputField emailAddress;
	[SerializeField]
	private InputField firstName;
	[SerializeField]
	private InputField lastName;
	[SerializeField]
	private GameObject subscribeButton;
	[SerializeField]
	private Text response;

	private EventSystem eventSystem;

	private float subscribeTimeout = 0;

	private void Start()
	{
		subscribeCanvas.SetActive(true);
		eventSystem = EventSystem.current;
	}

	private void Update()
	{
		if (IsSelected)
		{
			if (Input.anyKey)
			{
				subscribeTimeout = 0;
			}
			else
			{
				subscribeTimeout += Time.deltaTime;
				if (subscribeTimeout > SubscribeTimeout)
				{
					Deselect();
					ResetUI();
				}
			}
		}
	}

	public void Subscribe()
	{
		Deselect();
		if (!Regex.IsMatch(emailAddress.text, EmailAddressRegex))
		{
			StartCoroutine(SetResponseText(InvalidEmailAddress));
		}
		else
		{
			StartCoroutine(SetResponseText(SubscribeSuccess));
			StartMailChimpSubscribe(new MailChimpUser(emailAddress.text, firstName.text, lastName.text));
			ResetUI();
		}
	}

	public void StartMailChimpSubscribe(MailChimpUser mailChimpUser)
	{
		StartCoroutine(mailChimpSubscriber.Subscribe(mailChimpUser));
	}

	private IEnumerator SetResponseText(string newResponse)
	{
		response.text = newResponse;
		yield return new WaitUntil(() => IsSelected || !subscribePanel.activeSelf);
		response.text = "";
	}

	private void Deselect()
	{
		eventSystem.SetSelectedGameObject(null);
	}

	private void ResetUI()
	{
		emailAddress.text = "";
		firstName.text = "";
		lastName.text = "";
	}

	public void ToggleCanvas()
	{
		subscribeCanvas.SetActive(!subscribeCanvas.activeSelf);
	}

	public void ToggleCanvas(bool isEnabled)
	{
		subscribeCanvas.SetActive(isEnabled);
	}

	public void TogglePanel()
	{
		subscribePanel.SetActive(!subscribePanel.activeSelf);
	}

	public bool IsSelected
	{
		get
		{
			return eventSystem.currentSelectedGameObject != null;
		}
	}
}
