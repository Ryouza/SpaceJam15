using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 1;
		
	public Health (string tag) {
		if (tag == "block") {
			health = 1;
		}
		if (tag == "Player") {
			health = 5;
		}
		if (tag == "Monster") {
			health = 2;
		}
	}

	void Start () {

	}

	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}
}
