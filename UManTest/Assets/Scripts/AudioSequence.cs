using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioSequence : MonoBehaviour {

	public UnityEvent onSequenceEnd;

	private AudioSource[] objects;
	private int index;

	void OnEnable () {
		objects = GetComponentsInChildren<AudioSource> (true);
		index = -1;
		playNext ();
	}

	void playNext() {
		if (index >= 0)
			objects [index].gameObject.SetActive (false);
		if (++index < objects.Length) {
			objects [index].gameObject.SetActive (true);
			Invoke ("playNext", objects [index].clip.length);
		} else {
			onSequenceEnd.Invoke ();
		}
	}

	public void cancel () {
		CancelInvoke ();
		gameObject.SetActive (false);
		onSequenceEnd.Invoke ();
	}
}
