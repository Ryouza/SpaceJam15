using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public BlockType		type;

	private BlockData		data;

	// Use this for initialization
	void Start () {
		// Load in the attributes for this block type
		GameObject go = GameObject.Find("Main Camera");
		BlockTypes other = (BlockTypes) go.GetComponent(typeof(BlockTypes));
		data = other.initData (type);

		this.collider2D.enabled = false;
		if (data.bouncy) {
			PhysicsMaterial2D mat = Resources.Load ("Physics Materials/Rubber", typeof(PhysicsMaterial2D)) as PhysicsMaterial2D;
			if (mat == null) {
				Debug.Log ("Material not loaded.");
			}
			this.collider2D.sharedMaterial = mat;
		}
		if (!data.solid) {
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
		if (collidedWith.tag == "Weapon" && !data.indestructible) {
			data.health -= 1;// coll.gameObject.GetComponent<Attack>.damage;
			if (data.health <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
