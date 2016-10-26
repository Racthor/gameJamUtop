using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour {

	private Question[] questions;
	private int currentQuestion = 0;

    public GameObject prelude { get; private set; }
	public GameObject intro { get; private set; }
	public GameObject outro { get; private set; }
	public GameObject failure { get; private set; }

	public AudioSource voice { get; private set; }
	public AudioSource sounds { get; private set; }
	public AudioSource music { get; private set; }

	public AudioClip roomMusic;
	public AudioClip ambient;

    public GameObject examiner;

	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("VoiceSource").GetComponent<AudioSource>();
		sounds = GameObject.Find ("AmbientSoundSource").GetComponent<AudioSource>();
		music = GameObject.Find ("MusicSource").GetComponent<AudioSource>();
        examiner = GameObject.Find("Examiner").gameObject;

		questions = GetComponentsInChildren<Question>(true);

        prelude = transform.Find("Prelude").gameObject;
		intro = transform.FindChild ("Intro").gameObject;
        failure = transform.FindChild("Failure").gameObject;

        // disable the examiner at the begening 
        // (he is not present during the prologue, and appear when intro start)
        examiner.SetActive(false);

        // Steve Jobs has no "standard" outro
        if (ScoreManager.getSceneIndex() != 2)
			outro = transform.FindChild ("Outro").gameObject;

		if (ambient != null) {
			sounds.clip = ambient;
			sounds.Play ();
		}

		if (roomMusic != null) {
			music.clip = roomMusic;
			music.Play ();
		}

        intro.GetComponent<RoomIntro>().setExaminer(examiner);

        // Set this from the editor to control when the intro starts
        prelude.GetComponent<Prelude>().setIntro(intro);
		prelude.SetActive (true);
	}

	public void nextQuestion() {
		questions [currentQuestion++].gameObject.SetActive (false);

		if (currentQuestion < questions.Length)
			questions [currentQuestion].gameObject.SetActive (true);
		else {
			Debug.Log ("Outro!");
			ScoreManager.playOutro (this);
		}
	}

	public void beginQuestions() {
		questions [0].gameObject.SetActive (true);
	}

	public void nextScene() {
		ScoreManager.changeScene ();
	}
}
