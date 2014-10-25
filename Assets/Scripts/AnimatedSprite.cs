using UnityEngine;
using System.Collections;

public class AnimatedSprite : MonoBehaviour {

	public float maxSpeed = 0.1f;
	public int timeMax = 2;
	int direction;
	int time;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		direction = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//rigidbody2D.velocity = new Vector2 (Mathf.Lerp(0, Input.GetAxis("Horizontal") * maxSpeed, 10.0f), Mathf.Lerp(0, Input.GetAxis("Vertical") * maxSpeed, 10.0f)) ;
		if (direction == 0) {
			bool moveUp = Input.GetKey (KeyCode.UpArrow);
			bool moveDown = Input.GetKey (KeyCode.DownArrow);
			bool moveLeft = Input.GetKey (KeyCode.LeftArrow);
			bool moveRight = Input.GetKey (KeyCode.RightArrow);
			
			if (moveUp) {
				direction = 1;
				time = timeMax;
				anim.SetBool ("MoveUp", true);
				anim.SetBool ("MoveDown", false);
				anim.SetBool ("MoveLeft", false);
				anim.SetBool ("MoveRight", false);
			} else if (moveDown) {
				direction = 2;
				time = timeMax;
				anim.SetBool ("MoveUp", false);
				anim.SetBool ("MoveDown", true);
				anim.SetBool ("MoveLeft", false);
				anim.SetBool ("MoveRight", false);
			} else if (moveLeft) {
				direction = 3;
				time = timeMax;
				anim.SetBool ("MoveUp", false);
				anim.SetBool ("MoveDown", false);
				anim.SetBool ("MoveLeft", true);
				anim.SetBool ("MoveRight", false);
			} else if (moveRight) {
				direction = 4;
				time = timeMax;
				anim.SetBool ("MoveUp", false);
				anim.SetBool ("MoveDown", false);
				anim.SetBool ("MoveLeft", false);
				anim.SetBool ("MoveRight", true);
			}
		} else {
			switch (direction) {
			case 1:
				rigidbody2D.velocity = new Vector2 (0f, maxSpeed);
				break;
			case 2:
				rigidbody2D.velocity = new Vector2 (0f, -maxSpeed);
				break;
			case 3:
				rigidbody2D.velocity = new Vector2 (-maxSpeed, 0f);
				break;
			case 4:
				rigidbody2D.velocity = new Vector2 (maxSpeed, 0f);
				break;
			}
			
			time--;
			if (time <= 0) {
				direction = 0;
				rigidbody2D.velocity = new Vector2 (0f, 0f);
			}
		}
	}
}
