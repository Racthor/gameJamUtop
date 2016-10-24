using UnityEngine;
using System.Collections;

public class ExaminerBehaviour : MonoBehaviour {

    // Use this for initialization
    void Start() {
        // setHappy();
    }

    // Update is called once per frame
    void Update() {
        // setHappy();
    }

    public void playBehaviour(string behaviour = "thinking")
    {
        
        if (behaviour != "happy" || behaviour != "sad" || behaviour != "thinking")
        {
            Debug.Log("unexpected string (" + behaviour + ") for examiner behaviour");
        }
        

        GetComponent<Animator>().SetTrigger(behaviour);
    }
}
