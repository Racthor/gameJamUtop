using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour {

	// The level this question belongs to
	public int level;

	// How much time the player is given to answer
	public float timeout;

	//Scores associated to the timeout
	public int scoreTimeoutPaul;
	public int scoreTimeoutUman;

	// The room where this question is asked
	private Room room;

	private float timeoutTimestamp;
	private bool answered;

	public void answer (int scorePaul, int scoreUman) {
		//ScoreManager.jaugePaul += scorePaul;
		//ScoreManager.jaugeUman += scoreUman;

		ScoreManager.jaugePerLevel_Paul [level] += scorePaul;
		ScoreManager.jaugePerLevel_Uman [level] += scoreUman;

		Debug.Log ("Answered question, scores: Paul:" + ScoreManager.jaugePerLevel_Paul [level] + ",U-man:" + ScoreManager.jaugePerLevel_Uman [level]);
		room.nextQuestion ();
	}

	// Use this for initialization
	void OnEnable () {
		room = GetComponentInParent<Room> ();
		timeoutTimestamp = Time.time + timeout;
		answered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeoutTimestamp && !answered)
			answer (scoreTimeoutPaul, scoreTimeoutUman);
	}
}
