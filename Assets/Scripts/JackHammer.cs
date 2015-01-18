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
		attack.Damage(this.gameObject, ref temp);
	}
}