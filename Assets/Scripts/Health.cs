using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 1;

	//Sets health of object attached to it.
	void set (string tag) {
		if (tag == "Block") {
			health = 2;
		}
		if (tag == "Player") {
			health = 5;
		}
		if (tag == "Monster") {
			health = 2;
		}
	}

	void Start () {
		set (this.gameObject.tag);
	}

	//If health of object is less than or equal to 0, destroy object.
	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}
}
