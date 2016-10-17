using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class OnAnswerEvent : UnityEvent<int, int> {
}

public class Answer : MonoBehaviour {

	public int scorePaul;
	public int scoreUman;
	public string reactionText;
	public AudioClip reactionClip;

	public OnAnswerEvent answerEvent;

	private Question question;
	private Button button;

	void Start() {
//		Debug.Log ("coucou");
		if (answerEvent == null)
			answerEvent = new OnAnswerEvent ();
		
		question = GetComponentInParent<Question>();
		button = GetComponent<Button> ();
		button.onClick.AddListener (onclick);
	}

	public void onclick() {
//		Debug.Log ("clicked");
		answerEvent.Invoke(scorePaul, scoreUman);

		question.room.voice.Stop();

		Invoke("answerQuestion", 0.5f);
	}

	private void answerQuestion() {
		question.answer (scorePaul, scoreUman, reactionText, reactionClip);
	}
}