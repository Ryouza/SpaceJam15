using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	float jack_damage = 0;
	float monster_damage = 0;

	void Damage(GameObject a, ref GameObject b) {
		Health health = b.GetComponent< Health > ();
		if (a.gameObject.tag == "Weapon") {
			health.health -= jack_damage;
		}
		if (a.gameObject.tag == "Monster") {
			health.health -= monster_damage;
		}
	}
}
