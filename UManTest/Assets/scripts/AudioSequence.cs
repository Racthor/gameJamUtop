using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSequence : MonoBehaviour {

	private AudioSource[] objects;
	private int index;

	// Use this for initialization
	void OnEnable () {
		objects = GetComponentsInChildren<AudioSource> (true);
		index = -1;
		playNext ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playNext() {
		if (++index < objects.Length) {
			objects [index].gameObject.SetActive (true);
			Invoke ("playNext", objects [index].clip.length);
		} else {
			GetComponentInParent<Room> ().nextScene ();
		}
	}
}
