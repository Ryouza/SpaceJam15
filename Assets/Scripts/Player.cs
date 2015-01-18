using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed; //Horizontal speed
	public float jumpSpeed; //Vertical speed
	public float gravity; //Gravity
	private Vector2 moveDirection = Vector2.zero; //Vector which moves player
	
	private float waterSpeed;
	private float waterJump;
	private float waterGrav;
	
	private float currSpeed;
	private float currJump;
	private float currGrav;
	
	public bool isGrounded; //Checks whether player is on blocks or not
	public bool faceRight; //Checks which direction player is facing
	public bool attacking; //Checks if player is attacking
	public KeyCode key = KeyCode.K; //Button for attacking
	public GameObject weapon; //GameObject that is created for attacking
	Transform sprite;
	Animator anim;
	
	public int maxInvinFrames;
	private int invinFrames;
	public bool invin;
	
	public int watersTouched = 0;
	
	void Start() {
		isGrounded = false;
		faceRight = true;
		attacking = false;
		sprite = transform.GetChild(0);
		anim = sprite.GetComponent<Animator> ();
		
		currSpeed = speed;
		currJump = jumpSpeed;
		currGrav = gravity;
		
		waterSpeed = speed / 2.5f;
		waterGrav = gravity / 2f;
		waterJump = jumpSpeed;
		
		invinFrames = 0;
		invin = false;
		
	}
	
	void FixedUpdate() {
		if (invin) {
			invinFrames++;
		}
		if (invinFrames >= maxInvinFrames) {
			invin = false;
			invinFrames = 0;
		}
	}
	
	void Update() {
		//If attacking, player can not move horizontally
		if (!attacking && isGrounded) {
			anim.SetInteger("state", 0);
		}
		if ((!attacking && isGrounded) || !isGrounded) {
			moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
		}
		
		//If horizontal movement of player is pos, then faceRight becomes true.
		//If horizontal movement of player is neg, then faceRight becomes false.
		if (moveDirection.x > 0) {
			faceRight = true;
			sprite.localScale = new Vector3 (Mathf.Abs (sprite.localScale.x), sprite.localScale.y, sprite.localScale.z);
			anim.SetInteger("state", 2);
		} else if (moveDirection.x < 0) {
			faceRight = false;
			sprite.localScale = new Vector3 (-1 * Mathf.Abs (sprite.localScale.x), sprite.localScale.y, sprite.localScale.z);
			anim.SetInteger("state", 2);
		}
		//MoveDirection is multiplied with speed.
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= currSpeed;
		rigidbody2D.AddForce(new Vector2(0, -currGrav * Time.deltaTime));
		if (Mathf.Abs(moveDirection.x) >= currSpeed) {
			moveDirection.x = currSpeed * Mathf.Sign(moveDirection.x);
		}
		if(isGrounded) {
			rigidbody2D.AddForce(new Vector2(0, currGrav * Time.deltaTime));
		}
		//If isGrounded is false, add negative y force on player allows for aerial attack.
		if (!isGrounded) {
			if (Input.GetKeyDown(key)) {
				Attack (ref attacking, isGrounded);
			}
		}
		//If isGrounded is true, allows jumping and ground attacks
		if (isGrounded) {
			if (Input.GetButton("Jump")) {
				if(!attacking) {
					anim.SetInteger("state", 3);
					rigidbody2D.AddForce (new Vector2(0, moveDirection.y));
					rigidbody2D.AddForce (new Vector2(0, currJump));
					isGrounded = false;
				}
			}
			if (Input.GetKeyDown(key)) {
				anim.SetInteger("state", 1);
				Attack(ref attacking, isGrounded);
			}
		}
		//Moves player using velocity
		rigidbody2D.velocity += (moveDirection * Time.deltaTime);
		
		// If the player is touching any amount of water, slow him down
		if (watersTouched == 0) {
			currSpeed = speed;
			currJump = jumpSpeed;
			currGrav = gravity;
		}
		else {
			currSpeed = waterSpeed;
			currJump = waterJump;
			currGrav = waterGrav;
		}
	}
	
	//IEnumerator which destroys Children[1] and turns attacking false;
	IEnumerator DestroyWeapon() {
		yield return new WaitForSeconds (0.5f);
		GameObject attack = transform.GetChild(1).gameObject;
		Destroy (attack);
		attacking = false;
		anim.SetInteger ("state", 0);
	}
	
	//When player collides with GameObject with tag block, isGrounded becomes true.
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Block") {
			isGrounded = true;
			anim.SetInteger("state", 0);
		}
	}
	
	void OnCollisionExit2D(Collision2D coll) {
		if(coll.gameObject.tag == "Block") {
			isGrounded = false;
		}
	}
	
	//Attack(ref bool attacking, bool isGrounded) runs the attack process.
	//It creates a GameObject, attack, which is an instantiated weapon.
	//The position of attack is based on isGrounded. If isGrounded is true, attack is either left or right
	//of player based on faceRight. If isGrounded if false, attack is below player.
	//Attacking is true while Attack is running. Player movement is restricted when attacking is true.
	//At the end of the attack, it calls DestroyWeapon to get rid of attack GameObject.
	void Attack (ref bool attacking, bool isGrounded) {
		if (!attacking) {
			attacking = true;
			GameObject attack;
			if(isGrounded) {
				if (faceRight) {
					attack = Instantiate(weapon, new Vector2(transform.position.x + 1.0f, transform.position.y),
					                     Quaternion.identity) as GameObject;
					
				} else {
					attack = Instantiate(weapon, new Vector2(transform.position.x - 1.0f, transform.position.y),
					                     Quaternion.identity) as GameObject;
				}
				moveDirection = Vector2.zero;
			} else {
				attack = Instantiate(weapon, new Vector2(transform.position.x, transform.position.y - 1.0f),
				                     weapon.transform.rotation) as GameObject;
			}
			attack.transform.parent = GameObject.Find(this.name).transform;
			Debug.Log (weapon.tag);
			StartCoroutine(DestroyWeapon());
		}
	}
}
