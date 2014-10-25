using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {
	public Texture2D health1;
	public Texture2D health2;
	public Texture2D health3;
	public static int lives = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(lives)
		{
		case 1:
			guiTexture.texture = health1;
			break;
			
		case 2:
			guiTexture.texture = health2;
			break;
			
		case 3: 
			guiTexture.texture =health3;
			break;
		case 0:
			//defeat script here
			break;
		}
	
	}
}
