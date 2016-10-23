using UnityEngine;
using System.Collections;

public class ExaminerSpawnCollider : MonoBehaviour {

    private Collider2D deskCollider;

    void Start()
    {
        deskCollider = GameObject.Find("Pictures").GetComponent<Pictures>().deskCollider;
    }

    // When Examiner is colliding with "this", 
    // stop Examiner movements,
    // and prevent other objects for colliding with him.
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag + " is colliding");

        // Only for the Examiner
        if (coll.gameObject.tag == "Examiner")
        {
            // freeze the examiner
            coll.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            // disable the Examiner collider
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // disable the ExaminerSpawnCollider collider (it has only to trigger once)
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // enable desk collider
            deskCollider.enabled = true;
        }
    }
}
