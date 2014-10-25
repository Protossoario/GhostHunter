using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	/* Directions:
	 * 0 = none
	 * 1 = up
	 * 2 = down
	 * 3 = left
	 * 4 = right
	 */
	public static int currTouch = 0;//so other scripts can know what touch is currently on screen
	[HideInInspector]
	public int touch2Watch = 64;
	public int dir = 0;
	PlayerScript ps;

	public void Start() {
		ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}
	
	public virtual void Update()//If your child class uses Update, you must call base.Update(); to get this functionality
	{
		//is there a touch on screen?
		if (Input.touches.Length <= 0)
		{
			OnNoTouches();
		}
		else //if there is a touch
		{
			//loop through all the the touches on screen
			for (int i = 0; i < Input.touchCount; i++)
			{
				currTouch = i;
				//executes this code for current touch (i) on screen
				if (this.guiTexture != null && (this.guiTexture.HitTest(Input.GetTouch(i).position)))
				{
					//if current touch hits our guitexture, run this code
					if (Input.GetTouch(i).phase == TouchPhase.Began)
					{
						OnTouchBegan();
						touch2Watch = currTouch;
					}
					if (Input.GetTouch(i).phase == TouchPhase.Ended)
					{
						OnTouchEnded();
					}
					if (Input.GetTouch(i).phase == TouchPhase.Moved)
					{
						OnTouchMoved();
					}
					if (Input.GetTouch(i).phase == TouchPhase.Stationary)
					{
						OnTouchStayed();
					}
				}
				
				//outside so it doesn't require the touch to be over the guitexture
				switch (Input.GetTouch(i).phase)
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
	public void OnNoTouches(){}
	public void OnTouchBegan(){
		print (name + " is not using OnTouchBegan");
	}
	public  void OnTouchEnded(){
		if (dir == 1)
		{
			ps.setMoveUp(true);
		}
		else if (dir == 2)
		{
			ps.setMoveDown(true);
		}
		else if (dir == 3)
		{
			ps.setMoveLeft(true);
		}
		else if (dir == 4)
		{
			ps.setMoveRight(true);
		}
	}
	public void OnTouchMoved(){}
	public void OnTouchStayed(){}
	public void OnTouchBeganAnywhere(){}
	public void OnTouchEndedAnywhere(){}
	public void OnTouchMovedAnywhere(){}
	public void OnTouchStayedAnywhere(){}
}
