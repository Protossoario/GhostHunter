using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {
	float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = 300;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			Vibration.Cancel();
			Application.LoadLevel("SweetVictory");
		}
		int minutes = (int) timeLeft / 60;
		int seconds = (int) (timeLeft % 60);
		this.GetComponent<GUIText>().text = (minutes) + ":" + (seconds);
	}
}
