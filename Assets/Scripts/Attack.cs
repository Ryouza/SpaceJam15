using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	float jack_damage = 1;
	float monster_damage = 0;
	float lava_damage = 1;

	//Checks what type of object a is. If object a is a weapon, it deals weapon damage
	//to object b. If it is a monster, it deals monster damage to object b.
	public void Damage(GameObject a, ref GameObject b) {
		Health health = b.GetComponent< Health > ();
		if (health != null) {
			if (b.gameObject.tag == "Player") {
				Player player = b.gameObject.GetComponent<Player>() as Player;
				if (player.invin) return;
				else {
					player.invin = true;
				}
			}
			if (a.gameObject.tag == "Weapon") {
				health.health -= jack_damage;
			}
			if (a.gameObject.tag == "Monster") {
				health.health -= monster_damage;
			}
			if (a.gameObject.tag == "Lava") {
				health.health -= lava_damage;
			}
		}
	}
}
