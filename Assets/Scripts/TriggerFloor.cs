using UnityEngine;
using System.Collections;

public class TriggerFloor : MonoBehaviour {
	GameObject player;
	GameObject[] trapWalls;
	Walls ws;
	bool change;
	int precisionGap;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		trapWalls = GameObject.FindGameObjectsWithTag ("TrapWall");
		change = true;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		for (int i = 0; i < trapWalls.Length; i++) {
			ws = trapWalls[i].GetComponent<Walls> ();
			if (ws != null) {
					ws.changeCollider ();
			}
		}
	}
}
