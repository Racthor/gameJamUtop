using UnityEngine;
using System.Collections;

public class SetExaminerBehavior : MonoBehaviour {

	public string behaviour;
	// Use this for initialization
	void Start () {
	
		Room room = GetComponentInParent<Room> ();
		room.examiner.GetComponent<ExaminerBehaviour> ().playBehaviour (behaviour);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
