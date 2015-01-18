using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	void Start(){
		Color portal = Color.magenta;
		portal.a = 0.5f;
		this.gameObject.renderer.material.color = portal;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameObject collidedWith = coll.gameObject;

		GameObject camera = GameObject.Find("mainCamera");
		NextLevel next = (NextLevel)camera.GetComponent<NextLevel>();		
		
		if (collidedWith.tag == "Player") {
			Application.LoadLevel(next.nextLevel);
		}
	}
}
