using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	void Start(){
		Material mat = Resources.Load ("Textures/Portal", typeof(Material)) as Material;
		this.gameObject.renderer.material = mat;
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
