using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 1;

	//Sets health of object attached to it.
	void set (string tag) {
		if (tag == "Block") {
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
		set (this.gameObject.tag);
	}

	//If health of object is less than or equal to 0, destroy object.
	void Update () {
		if (health <= 0) {
			if (this.gameObject.tag == "Player") {
				GameObject camera = GameObject.Find("mainCamera");
				NextLevel next = (NextLevel)camera.GetComponent<NextLevel>();		
				
				if (this.gameObject.tag == "Player") {
					Application.LoadLevel(next.currLevel);
				}
			}
			Destroy (this.gameObject);
		}
	}
}
