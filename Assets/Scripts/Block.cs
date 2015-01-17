using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public bool			    bouncy;
	public int				health;
	public bool				solid;
	public bool				indestructible;

	// Use this for initialization
	void Start () {
		this.collider2D.enabled = false;
		if (bouncy) {
			PhysicsMaterial2D mat = Resources.Load ("Physics Materials/Rubber", typeof(PhysicsMaterial2D)) as PhysicsMaterial2D;
			if (mat == null) {
				Debug.Log ("Material not loaded.");
			}
			this.collider2D.sharedMaterial = mat;
		}
		if (!solid) {
			this.collider2D.isTrigger = true;
		} else {
			this.collider2D.enabled = true;
			this.collider2D.isTrigger = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Weapon" && !indestructible) {
			this.health -= 1;// coll.gameObject.GetComponent<Attack>.damage;
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
