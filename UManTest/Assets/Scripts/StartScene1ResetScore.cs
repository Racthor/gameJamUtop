using UnityEngine;
using System.Collections;

public class StartScene1ResetScore : MonoBehaviour {

    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        scoreManager = GetComponent<ScoreManager>();
        scoreManager.init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
