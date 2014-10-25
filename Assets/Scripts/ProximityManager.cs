using UnityEngine;
using System.Collections;

public class ProximityManager : MonoBehaviour {
	GameObject player;
	GameObject[] enemyList;
	float[] enemyDistance;
	float shorterDistance;

	private const float RANGE0 = 0.5f;
	private const float RANGE1 = 1f;
	private const float RANGE2 = 1.5f;
	private const float RANGE3 = 2f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
		enemyDistance = new float[enemyList.Length];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		shorterDistance = 9999999999999f;
		for (int i = 0; i < enemyList.Length; i++) {
			enemyDistance[i] = Vector3.Distance(enemyList[i].transform.position, player.transform.position);
			Debug.Log(enemyDistance[i]);
			if (enemyDistance[i] < shorterDistance) {
				shorterDistance = enemyDistance[i];
			}
		}

		if (shorterDistance < RANGE0) {
			VibrationModule.playPattern(3);
		}
		else if (shorterDistance < RANGE1) {
			VibrationModule.playPattern(2);
		}
		else if (shorterDistance < RANGE2) {
			VibrationModule.playPattern(1);
		}
		else if (shorterDistance < RANGE3) {
			VibrationModule.playPattern(0);
		}
		else {
			VibrationModule.stop();
		}
	}
}
