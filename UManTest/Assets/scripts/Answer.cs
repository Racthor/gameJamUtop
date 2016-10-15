using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {

	public int scorePaul;
	public int scoreUman;

	private Question question;

	void Start() {
//		Debug.Log ("coucou");
		question = GetComponentInParent<Question>();
		Button button = GetComponent<Button> ();
		button.onClick.AddListener (onclick);
	}

	public void onclick() {
//		Debug.Log ("clicked");
		question.answer (scorePaul, scoreUman);
	}
		
}
