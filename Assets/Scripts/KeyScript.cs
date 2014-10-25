using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
	public Texture2D key0;
	public Texture2D key1;
	public static bool dungeonKey = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(dungeonKey)
			guiTexture.texture = key1;
		else
			guiTexture.texture = key0;
	
	}
}
