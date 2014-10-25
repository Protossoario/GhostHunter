using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {
	public int dir;
	[HideInInspector]
	public int currTouch = 0;//so other scripts can know what touch is currently on screen
	public int touch2Watch = 64;
	

	
	public virtual void Update()//If your child class uses Update, you must call base.Update(); to get this functionality
	{
		//is there a touch on screen?
		if(Input.touches.Length <= 0)
		{
			OnNoTouches();
		}
		else //if there is a touch
		{
			//loop through all the the touches on screen
			for(int i = 0; i < Input.touchCount; i++)
			{
				currTouch = i;
				//executes this code for current touch (i) on screen
				if(this.guiTexture != null && (this.guiTexture.HitTest(Input.GetTouch(i).position)))
				{
					//if current touch hits our guitexture, run this code
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						OnTouchBegan();
						touch2Watch = currTouch;
					}
					if(Input.GetTouch(i).phase == TouchPhase.Ended)
					{
						OnTouchEnded();
					}
					if(Input.GetTouch(i).phase == TouchPhase.Moved)
					{
						OnTouchMoved();
					}
					if(Input.GetTouch(i).phase == TouchPhase.Stationary)
					{
						OnTouchStayed();
					}
				}
				
				//outside so it doesn't require the touch to be over the guitexture
				switch(Input.GetTouch(i).phase)
				{
				case TouchPhase.Began:
					OnTouchBeganAnywhere();
					break;
				case TouchPhase.Ended:
					OnTouchEndedAnywhere();
					break;
				case TouchPhase.Moved:
					OnTouchMovedAnywhere();
					break;
				case TouchPhase.Stationary:
					OnTouchStayedAnywhere();
					break;
				}
			}
		}
	}
	
	//the default functions, define what will happen if the child doesn't override these functions
	public  void OnNoTouches(){}
	public  void OnTouchBegan(){
		print (name + " is not using OnTouchBegan"); 
		switch(dir) {
		case 1:

			PlayerScript.moveUp = true;
			break;
		case 2:
			PlayerScript.moveDown = true;
			break;
		case 3:
			PlayerScript.moveLeft = true;
			break;
		case 4:
			PlayerScript.moveRight = true;
			break;
		}
		
	}
	public  void OnTouchEnded(){
		switch(dir) {
		case 1:
			
			PlayerScript.moveUp = false;
			break;
		case 2:
			PlayerScript.moveDown = false;
			break;
		case 3:
			PlayerScript.moveLeft = false;
			break;
		case 4:
			PlayerScript.moveRight = false;
			break;
		case 5:
			Application.LoadLevel("EscapeDungeon");
			break;
		}

	}
	public  void OnTouchMoved(){}
	public  void OnTouchStayed(){}
	public  void OnTouchBeganAnywhere(){}
	public  void OnTouchEndedAnywhere(){

			
			PlayerScript.moveUp = PlayerScript.moveDown = PlayerScript.moveLeft = PlayerScript.moveRight = false;
			

	}
	public  void OnTouchMovedAnywhere(){}
	public  void OnTouchStayedAnywhere(){}
}