﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Room : MonoBehaviour {

	private Question[] questions;
	private int currentQuestion = 0;

	// Use this for initialization
	void Start () {
		questions = GetComponentsInChildren<Question>(true);

		questions [0].gameObject.SetActive (true);
	}

	public void nextQuestion() {
		questions [currentQuestion++].gameObject.SetActive (false);

		if (currentQuestion < questions.Length)
			questions [currentQuestion].gameObject.SetActive (true);
		else {
			Debug.Log ("Next scene!");
			ScoreManager.changeScene ();
		}
	}
}
