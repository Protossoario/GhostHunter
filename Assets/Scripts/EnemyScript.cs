using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

[RequireComponent (typeof (Seeker))]
public class EnemyScript : MonoBehaviour {
	protected Seeker seeker;
	protected Transform tr;
	protected Transform playerTr;

	Random rnd = new Random ();

	float deltaX;
	float deltaY;
	int nodoActual;
	int direction;
	int time;
	public int timeMax = 100;
	Animator anim;
	public int life = 1;
	float maxSpeed = 2f;
	bool moving;
	bool requestingPath;
	List<Vector3> path;

	// Use this for initialization
	void Start () {
		time = 0;
		direction = 0;
		nodoActual = 0;
		anim = GetComponent<Animator>();
		requestingPath = false;
		moving = false;

		seeker = GetComponent<Seeker>();
		tr = GetComponent<Transform>();
		playerTr = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public  void reduceLife(int dam) {
		if (anim.GetBool ("SpiderUp")) {
			anim.SetBool("DamageUp", true);
			anim.SetBool("DamageDown", false);
			anim.SetBool("DamageLeft", false);
			anim.SetBool("DamageRight", false);
		} else if (anim.GetBool ("SpiderDown")) {
			anim.SetBool("DamageUp", false);
			anim.SetBool("DamageDown", true);
			anim.SetBool("DamageLeft", false);
			anim.SetBool("DamageRight", false);
		} else if (anim.GetBool ("SpiderLeft")) {
			anim.SetBool("DamageUp", false);
			anim.SetBool("DamageDown", false);
			anim.SetBool("DamageLeft", true);
			anim.SetBool("DamageRight", false);
		} else if (anim.GetBool ("SpiderRight")) {
			anim.SetBool("DamageUp", false);
			anim.SetBool("DamageDown", false);
			anim.SetBool("DamageLeft", false);
			anim.SetBool("DamageRight", true);
		}
		
		life -= dam;
	}

	void onPathComplete(Path p) {
		path = p.vectorPath;
		nodoActual = 1;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
			/* Obtener un camino del objeto Seeker */
		if (time <= 0) {
			seeker.StartPath(tr.position, playerTr.position, onPathComplete);
			time = timeMax;
			requestingPath = true;
		}

		if (path != null) {
			deltaX = (path[nodoActual].x - this.transform.position.x)*Time.deltaTime;
			deltaY = (path[nodoActual].y - this.transform.position.y)*Time.deltaTime;
			this.transform.Translate(deltaX * maxSpeed, deltaY * maxSpeed, this.transform.position.z);

			if (deltaX > 0) {
				anim.SetBool("SpiderUp", false);
				anim.SetBool("SpiderDown", false);
				anim.SetBool("SpiderRight", true);
				anim.SetBool("SpiderLeft", false);
			} else if (deltaX < 0) {
				anim.SetBool("SpiderUp", false);
				anim.SetBool("SpiderDown", false);
				anim.SetBool("SpiderRight", false);
				anim.SetBool("SpiderLeft", true);
			} else if ( deltaY > 0) {
				anim.SetBool("SpiderUp", true);
				anim.SetBool("SpiderDown", false);
				anim.SetBool("SpiderRight", false);
				anim.SetBool("SpiderLeft", false);
			} else if (deltaY < 0) {
				anim.SetBool("SpiderUp", false);
				anim.SetBool("SpiderDown", true);
				anim.SetBool("SpiderRight", false);
				anim.SetBool("SpiderLeft", false);
			}


			if (this.transform.position.x == path[nodoActual].x && this.transform.position.y == path[nodoActual].y) {
				nodoActual++;
			}
		}
			/*posActualX = this.transform.position.x;
			posActualY = this.transform.position.y;
			if (path != null) {
				if (path[nodoActual].y > posActualY) {
					direction = 1;
				} else if (path[nodoActual].y < posActualY) {
					direction = 2;
				} else if (path[nodoActual].x < posActualX ) {
					direction = 3;
				} else if (path[nodoActual].x > posActualX) {
					direction = 4;
				}
				if (path[nodoActual].x == posActualX && path[nodoActual].y == posActualY)
					nodoActual++;
			} */
		// El turno se esta ejecutando y la arania se esta desplazando de un tile a otro
			/*switch (direction) {
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
			}*/
			time--;
			
			/*if (time <= 0) {
				direction = 0;
				if (moving) {
					moving = false;
					AstarPath.active.UpdateGraphs(GetComponent<SpriteRenderer>().bounds);
				}
				rigidbody2D.velocity = new Vector2 (0f, 0f);
			}*/
	}

	void turnOffDamageAnimation() {
		anim.SetBool ("DamageUp", false);
		anim.SetBool ("DamageDown", false);
		anim.SetBool ("DamageLeft", false);
		anim.SetBool ("DamageRight", false);
	}
}
