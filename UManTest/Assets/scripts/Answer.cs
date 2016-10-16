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

	void Start() {
//		Debug.Log ("coucou");
		if (answerEvent == null)
			answerEvent = new OnAnswerEvent ();
		
		question = GetComponentInParent<Question>();
		Button button = GetComponent<Button> ();
		button.onClick.AddListener (onclick);
	}

	public void onclick() {
//		Debug.Log ("clicked");
		answerEvent.Invoke(scorePaul, scoreUman);

		Invoke("answerQuestion", 1);
	}

	private void answerQuestion() {
		question.answer (scorePaul, scoreUman, reactionText, reactionClip);
	}
}