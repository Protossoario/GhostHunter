using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {
	public bool collide;

	// Use this for initialization
	void Start () {
	}

	public void changeCollider() {
		collide = !collide;
		collider2D.enabled = collide;
		if (collide) {
			this.tag = "Wall";
		}
		else {
			this.tag = "FakeWall";
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
	}
}
