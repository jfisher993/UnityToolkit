using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrelloCard {

	private string name;
	private string desc;
	private string pos;
	private string idList;
	private string due;

	public TrelloCard(string name, string desc, string pos, string idList, string due = "null") {
		this.name = name;
		this.desc = desc;
		this.pos = pos;
		this.idList = idList;
		this.due = due;
	}

	public WWWForm GetPostBody() {
		WWWForm postBody = new WWWForm();
		postBody.AddField("name", name);
		postBody.AddField("desc", desc);
		postBody.AddField("pos", pos);
		postBody.AddField("due", due);
		postBody.AddField("idList", idList);
		return postBody;
	}

}
