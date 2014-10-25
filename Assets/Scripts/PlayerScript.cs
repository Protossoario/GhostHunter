using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public AudioClip swordSound;
	public AudioClip spiderSound;
	public float maxSpeed = 0.1f;
	public int timeMax = 2;
	public int life = 3;
	bool attacking;
	public string lvlChange;
	//public bool turn; // Check whether it's the players' turn to move, if true
	public static bool moveUp;
	public static bool moveDown;
	public static bool moveLeft;
	public static bool moveRight;
	/* Directions:
	 * 0 = none
	 * 1 = up
	 * 2 = down
	 * 3 = left
	 * 4 = right
	 */
	public static int direction = 0;
	int time;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		direction = 0;
		attacking = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			Application.LoadLevel("gameover");
			Vibration.Cancel();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (direction == 0  && !attacking) {
		Collider2D colUp = Physics2D.OverlapPoint(new Vector2(this.transform.position.x, this.transform.position.y + 0.32f));
		Collider2D colDown = Physics2D.OverlapPoint(new Vector2(this.transform.position.x, this.transform.position.y - 0.32f));
		Collider2D colLeft = Physics2D.OverlapPoint(new Vector2(this.transform.position.x - 0.32f, this.transform.position.y));
		Collider2D colRight = Physics2D.OverlapPoint(new Vector2(this.transform.position.x + 0.32f, this.transform.position.y));
	
		//moveUp = Input.GetKey (KeyCode.UpArrow);
		//moveDown = Input.GetKey (KeyCode.DownArrow);
		//moveLeft = Input.GetKey (KeyCode.LeftArrow);
		//moveRight = Input.GetKey (KeyCode.RightArrow);

		if (moveUp) {
				print ("entraste");
				//moveUp = false;
			if (colUp != null) {
				if (!colUp.CompareTag("Wall")) {
					direction = 1;
					time = timeMax;
					anim.SetBool ("MoveUp", true);
					anim.SetBool ("MoveDown", false);
					anim.SetBool ("MoveLeft", false);
					anim.SetBool ("MoveRight", false);
				}
			}
			else {
				direction = 1;
				time = timeMax;
				anim.SetBool ("MoveUp", true);
				anim.SetBool ("MoveDown", false);
				anim.SetBool ("MoveLeft", false);
				anim.SetBool ("MoveRight", false);
			}
		} else if (moveDown) {
				print ("entraste");
				//moveDown = false;
			if (colDown != null) {
				if (!colDown.CompareTag("Wall")) {
					direction = 2;
					time = timeMax;
					anim.SetBool ("MoveUp", false);
					anim.SetBool ("MoveDown", true);
					anim.SetBool ("MoveLeft", false);
					anim.SetBool ("MoveRight", false);
				}
			} else {
				direction = 2;
				time = timeMax;
				anim.SetBool ("MoveUp", false);
				anim.SetBool ("MoveDown", true);
				anim.SetBool ("MoveLeft", false);
				anim.SetBool ("MoveRight", false);
			}
		} else if (moveLeft) {
				print ("entraste");
				//moveLeft = false;
			if (colLeft != null) {
				if (!colLeft.CompareTag("Wall")) {
					direction = 3;
					time = timeMax;
					anim.SetBool ("MoveUp", false);
					anim.SetBool ("MoveDown", false);
					anim.SetBool ("MoveLeft", true);
					anim.SetBool ("MoveRight", false);
				}
			} else {
				direction = 3;
				time = timeMax;
				anim.SetBool ("MoveUp", false);
				anim.SetBool ("MoveDown", false);
				anim.SetBool ("MoveLeft", true);
				anim.SetBool ("MoveRight", false);
			}
		} else if (moveRight) {
				print ("entraste");
				//moveRight = false;
			if (colRight != null) {
				if (!colRight.CompareTag("Wall")) {
					direction = 4;
					time = timeMax;
					anim.SetBool ("MoveUp", false);
					anim.SetBool ("MoveDown", false);
					anim.SetBool ("MoveLeft", false);
					anim.SetBool ("MoveRight", true);
				}
			} else {
				direction = 4;
				time = timeMax;
				anim.SetBool ("MoveUp", false);
				anim.SetBool ("MoveDown", false);
				anim.SetBool ("MoveLeft", false);
				anim.SetBool ("MoveRight", true);
			}
		}
		}
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
			attacking = false;
		}
	}

	public void setMoveUp(bool move) {
		moveUp = move;
	}
	public void setMoveDown(bool move) {
		moveDown = move;
	}
	public void setMoveLeft(bool move) {
		moveLeft = move;
	}
	public void setMoveRight(bool move) {
		moveRight = move;
	}
	void turnOffDamageAnimation() {
		anim.SetBool ("DamageUp", false);
		anim.SetBool ("DamageDown", false);
		anim.SetBool ("DamageLeft", false);
		anim.SetBool ("DamageRight", false);
	}
	void turnOffMoveAnimation() {
		anim.SetBool ("MoveUp", false);
		anim.SetBool ("MoveDown", false);
		anim.SetBool ("MoveLeft", false);
		anim.SetBool ("MoveRight", false);
	}
	void turnOffAttackAnimation() {
		if (anim.GetBool ("AttackUp")) {
			anim.SetBool ("MoveUp", true);
			anim.SetBool ("MoveDown", false);
			anim.SetBool ("MoveLeft", false);
			anim.SetBool ("MoveRight", false);
		}
		else if (anim.GetBool ("AttackDown")) {
			anim.SetBool ("MoveUp", false);
			anim.SetBool ("MoveDown", true);
			anim.SetBool ("MoveLeft", false);
			anim.SetBool ("MoveRight", false);
		}
		else if (anim.GetBool ("AttackLeft")) {
			anim.SetBool ("MoveUp", false);
			anim.SetBool ("MoveDown", false);
			anim.SetBool ("MoveLeft", true);
			anim.SetBool ("MoveRight", false);
		}
		else if (anim.GetBool ("AttackRight")) {
			anim.SetBool ("MoveUp", false);
			anim.SetBool ("MoveDown", false);
			anim.SetBool ("MoveLeft", false);
			anim.SetBool ("MoveRight", true);
		}
		
		anim.SetBool ("AttackUp", false);
		anim.SetBool ("AttackDown", false);
		anim.SetBool ("AttackLeft", false);
		anim.SetBool ("AttackRight", false);
	}
}
