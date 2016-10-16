using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomIntro : MonoBehaviour {

	public AudioClip[] voiceClips;
	public string[] texts;

	private int currentClip;
	private Room room;
	private Text text;

	void OnEnable () {
		currentClip = -1;
		room = GetComponentInParent<Room> ();
		text = GetComponentInChildren<Text> ();

		Debug.Assert (voiceClips.Length == texts.Length);

		nextClip ();
	}

	void nextClip() {
		if (++currentClip < voiceClips.Length) {
			room.voice.clip = voiceClips [currentClip];
			room.voice.Play ();
			text.text = texts [currentClip];

			Invoke ("nextClip", room.voice.clip.length);
		} else {
			this.gameObject.SetActive (false);
			room.beginQuestions ();
		}
	}
}
