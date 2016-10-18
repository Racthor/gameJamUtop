using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour {

	private Question[] questions;
	private int currentQuestion = 0;

	public GameObject intro { get; private set; }
	public GameObject outro { get; private set; }
	public GameObject failure { get; private set; }

	public AudioSource voice { get; private set; }
	public AudioSource sounds { get; private set; }
	public AudioSource music { get; private set; }

	public AudioClip roomMusic;
	public AudioClip ambient;

	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("VoiceSource").GetComponent<AudioSource>();
		sounds = GameObject.Find ("AmbientSoundSource").GetComponent<AudioSource>();
		music = GameObject.Find ("MusicSource").GetComponent<AudioSource>();

		questions = GetComponentsInChildren<Question>(true);
		intro = transform.FindChild ("Intro").gameObject;
		// Steve Jobs has no "standard" outro
		if (ScoreManager.getSceneIndex() != 2)
			outro = transform.FindChild ("Outro").gameObject;
		failure = transform.FindChild ("Failure").gameObject;

		if (ambient != null) {
			sounds.clip = ambient;
			sounds.Play ();
		}

		if (roomMusic != null) {
			music.clip = roomMusic;
			music.Play ();
		}

		// Set this from the editor to control when the intro starts
		intro.SetActive (true);
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
