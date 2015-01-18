using UnityEngine;
using System.Collections;

public class JackHammer : MonoBehaviour {
	Attack attack;
	// Use this for initialization
	void Start () {
		attack = GetComponent<Attack> ();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		GameObject temp = coll.gameObject;
		Block block = (Block)temp.gameObject.GetComponent(typeof(Block));
		if (temp.tag == "Block" && block.data.indestructible) return;
		attack.Damage(this.gameObject, ref temp);
	}
}