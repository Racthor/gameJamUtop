using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour {

	public UnityEvent onCollision;

	void OnCollisionEnter2D(Collision2D other) {
		onCollision.Invoke ();
	}
}
