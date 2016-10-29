using UnityEngine;
using System.Collections;

public class StartScene1ResetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gameSystem = GameObject.Find ("GameSystem");
		if (gameSystem)
			gameSystem.GetComponent<ScoreManager>().init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
