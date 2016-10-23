using UnityEngine;
using System.Collections;

public class Pictures : MonoBehaviour {

    public Collider2D deskCollider;
    public GameObject examiner;
    public Collider2D examinerSpawnCollider; // for ending the examiner spawn moovement.

	// Use this for initialization
	void Start () {
        examiner = GameObject.Find("Examiner");
        deskCollider = GameObject.Find("Desk").GetComponent<Collider2D>();
        examinerSpawnCollider = GameObject.Find("ExaminerSpawnCollider").GetComponent<Collider2D>();
	}
}
