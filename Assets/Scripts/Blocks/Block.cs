using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public BlockType type;

	private BlockData data;

	// Use this for initialization
	void Start () {
		// Load in the attributes for this block type
		GameObject go = GameObject.Find("mainCamera");
		BlockTypes other = (BlockTypes) go.GetComponent(typeof(BlockTypes));
		data = other.initData (type);

		// Load in the specific block's auxilliary script
		gameObject.AddComponent(data.auxScript);

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
			this.collider2D.isTrigger = false;
		}
		this.collider2D.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Block Collide!");
		GameObject collidedWith = coll.gameObject;
		Attack attack = (Attack)this.gameObject.GetComponent(typeof(Attack));
		if (collidedWith.tag == "weapon" && !data.indestructible) {
			// attack.Damage(collidedWith, this.gameObject);
		}
	}
}
