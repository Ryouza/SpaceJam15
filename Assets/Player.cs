using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float gravity;
	private Vector2 moveDirection = Vector2.zero;
	public bool isGrounded;

	void Start() {
		isGrounded = false;
	}

	void Update() {
		moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		if (!isGrounded) {
			rigidbody2D.AddForce(new Vector2(0, -gravity * Time.deltaTime));
		}
		if (isGrounded) {
			if (Input.GetButton("Jump")) {
				rigidbody2D.AddForce (new Vector2(0, moveDirection.y));
				rigidbody2D.AddForce (new Vector2(0, jumpSpeed));
				isGrounded = false;
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
