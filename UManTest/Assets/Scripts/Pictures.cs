using UnityEngine;
using System.Collections;

public class Pictures : MonoBehaviour {

    public BoxCollider2D deskCollider;
    public GameObject examiner;
    public BoxCollider2D examinerSpawnCollider; // for ending the examiner spawn moovement.

	// Use this for initialization
	void Start () {
        examiner = GameObject.Find("Examiner");
        deskCollider = GameObject.Find("Desk").GetComponent<BoxCollider2D>();
        examinerSpawnCollider = GameObject.Find("ExaminerSpawnCollider").GetComponent<BoxCollider2D>();
	}
}
