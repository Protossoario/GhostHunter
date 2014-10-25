using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	public string lvlChange;
	public int lvlIndex;
	void OnMouseDown()
	{
		Application.LoadLevel(lvlChange);
	}
}
