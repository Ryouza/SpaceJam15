using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float gravity;
	public bool isGrounded;
	public KeyCode key = KeyCode.K;
	public GameObject weapon;

	private Vector2 moveDirection = Vector2.zero;

	void Start() {
		isGrounded = false;
	}

	void Update() {
		moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		if (!isGrounded) {
			rigidbody2D.AddForce(new Vector2(0, -gravity * Time.deltaTime));
			if (Input.GetKeyDown(key) {
				
			}
		}
		if (isGrounded) {
			if (Input.GetButton("Jump")) {
				rigidbody2D.AddForce (new Vector2(0, moveDirection.y));
				rigidbody2D.AddForce (new Vector2(0, jumpSpeed));
				isGrounded = false;
			}
			if (Input.GetKeyDown(key) {
				GameObject attack = Instantiate(weapon, new Vector2(0, 0), Quaternion.identity);
				attack.transform.parent = GameObject.Find(self).transform;
			}
		}
		Debug.Log (rigidbody2D.velocity);
		rigidbody2D.velocity += (moveDirection * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.tag == "ground") {
			isGrounded = true;
		}
	}
}
