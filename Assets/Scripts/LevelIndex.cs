using UnityEngine;
using System.Collections;

public class LevelIndex : MonoBehaviour {

	public static bool[] levels= new bool[10];
	public  static int index;

	public void openLevel(int actualLvl)
	{
		levels[actualLvl+1] = true;
	}

}
