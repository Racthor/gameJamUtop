using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Question : MonoBehaviour {

    public GameObject[] questionPictures;

	public AudioClip questionClip;

	// How much time the player is given to answer
	public float timeout = 7.0f;

	//Scores associated to the timeout
	public int scoreTimeoutPaul;
	public int scoreTimeoutUman;

	public string timeoutReactionText;
	public AudioClip timeoutReactionClip;

    public string examinerBehaviour;

    public UnityEvent onTimeoutEvent;

	// The room where this question is asked
	public Room room { get; private set; }

	private float timeoutTimestamp;
	private bool answered;

	public void answer (int scorePaul, int scoreUman, string reactionText, AudioClip reactionClip, string examinerBehaviour)
    {
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

        // Play animation for the examiner
        this.examinerBehaviour = examinerBehaviour;
        animateExaminer();

        // remove the answers pictures from the scene
        destroyQuestionPictures();

		Invoke("nextQuestion", nextQuestionDelay);
	}

    private void animateExaminer()
    {
        room.examiner.GetComponent<ExaminerBehaviour>().playBehaviour(examinerBehaviour);
    }

	private void nextQuestion() {
		room.nextQuestion ();
	}

	// Use this for initialization
	void OnEnable () {
        Debug.Log("EnableQuestion");

        initPictures();

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

    // Disable all the picture collider at the begining,
    // it prevent them from staying out while spawning
    private void initPictures()
    {
        foreach (GameObject questionPicture in questionPictures)
        {
            questionPicture.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Unfreeze the pictures in the Y axe (but still freeze them in rotation and in X axe)
    private void spawnQuestionPictures()
    {
        Debug.Log("spawnQuestionPictures");
        foreach (GameObject questionPicture in questionPictures)
        {
            questionPicture.GetComponent<BoxCollider2D>().enabled = true;

            questionPicture.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            questionPicture.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            questionPicture.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }

    // Remove the Question pictures
    void destroyQuestionPictures()
    {
        Debug.Log("remove question pictures");
        foreach (GameObject questionPicture in questionPictures)
        {
            questionPicture.SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
		if (Time.time > timeoutTimestamp && !answered) {
			onTimeoutEvent.Invoke ();
			answer (scoreTimeoutPaul, scoreTimeoutUman, timeoutReactionText, timeoutReactionClip, examinerBehaviour);
		}
	}
}
