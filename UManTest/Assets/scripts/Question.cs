using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {

	public AudioClip questionClip;

	// How much time the player is given to answer
	public float timeout;

	//Scores associated to the timeout
	public int scoreTimeoutPaul;
	public int scoreTimeoutUman;

	public string timeoutReactionText;
	public AudioClip timeoutReactionClip;


	// The room where this question is asked
	public Room room { get; private set; }

	private float timeoutTimestamp;
	private bool answered;

	public void answer (int scorePaul, int scoreUman, string reactionText, AudioClip reactionClip) {

		ScoreManager.increasePaul(scorePaul);
		ScoreManager.increaseUman(scoreUman);

		Debug.Log ("Answered question, scores: Paul:" + ScoreManager.jaugePerLevel_Paul [ScoreManager.getSceneIndex()] + ",U-man:" + ScoreManager.jaugePerLevel_Uman [ScoreManager.getSceneIndex()]);
		answered = true;

		// Set reaction text at the top of the screen
		Text questionText = GetComponentInChildren<Text> ();
		questionText.text = reactionText;

		float nextQuestionDelay = 2.0f;
		// Play reaction audio clip
		if (reactionClip != null) {
			room.voice.clip = reactionClip;
			room.voice.Play ();
			nextQuestionDelay += reactionClip.length;
		}
		Invoke("nextQuestion", nextQuestionDelay);
	}

	private void nextQuestion() {
		room.nextQuestion ();
	}

	// Use this for initialization
	void OnEnable () {
		room = GetComponentInParent<Room> ();
		timeoutTimestamp = Time.time + timeout;
		answered = false;

		room.voice.Stop ();
		// Play question audio clip
		if (questionClip != null) {
			room.voice.clip = questionClip;
			room.voice.Play ();
			timeoutTimestamp += questionClip.length;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeoutTimestamp && !answered)
			answer (scoreTimeoutPaul, scoreTimeoutUman, timeoutReactionText, timeoutReactionClip);
	}
}
