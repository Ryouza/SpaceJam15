using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	private float		knockback = 125;

	void Start(){
		this.gameObject.tag = "Lava";
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameObject collidedWith = coll.gameObject;
		Attack attack = (Attack)this.gameObject.GetComponent(typeof(Attack));
		Vector2 vel = collidedWith.rigidbody2D.velocity;

		if (collidedWith.tag == "Player") {
			attack.Damage (this.gameObject, ref collidedWith);
		}

		// If player isn't moving vertically, bounce him up. If not, bounce him in opposite direction
		if (vel.y == 0) {
			collidedWith.rigidbody2D.AddForce(new Vector2(-vel.x * knockback, 5 * knockback));
		}
		else {
			collidedWith.rigidbody2D.AddForce(new Vector2(-vel.x * knockback, -vel.y * knockback));
		}
	}

}