using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Question : MonoBehaviour {

    public GameObject[] questionPictures;

	public AudioClip questionClip;

	// How much time the player is given to answer
	public float timeout;

	//Scores associated to the timeout
	public int scoreTimeoutPaul;
	public int scoreTimeoutUman;

	public string timeoutReactionText;
	public AudioClip timeoutReactionClip;

	public UnityEvent onTimeoutEvent;

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

		float nextQuestionDelay = 1.0f;
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
        Debug.Log("EnableQuestion");
		room = GetComponentInParent<Room> ();
		timeoutTimestamp = Time.time + timeout;
		answered = false;

		room.voice.Stop ();

        spawnQuestionPictures();

		// Play question audio clip
		if (questionClip != null) {
			room.voice.clip = questionClip;
			room.voice.Play ();
			timeoutTimestamp += questionClip.length;
		}
	}
	
    // Unfreeze the pictures in the Y axe (but still freeze them in rotation and in X axe)
    void spawnQuestionPictures()
    {
        Debug.Log("spawnQuestionPictures");
        foreach (GameObject questionPicture in questionPictures)
        {
            Debug.Log("foreachInSpawnQuestionPictures");
            questionPicture.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            questionPicture.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            questionPicture.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }

	// Update is called once per frame
	void Update () {
		if (Time.time > timeoutTimestamp && !answered) {
			onTimeoutEvent.Invoke ();
			answer (scoreTimeoutPaul, scoreTimeoutUman, timeoutReactionText, timeoutReactionClip);
		}
	}
}
