using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Material mat = Resources.Load ("Textures/Water", typeof(Material)) as Material;
		this.gameObject.renderer.material = mat;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Player") {
			Player player = collidedWith.GetComponent<Player> ();
			player.watersTouched++;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Player") {
			Player player = collidedWith.GetComponent<Player> ();
			player.watersTouched--;
		}
	}

}
