using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public bool			    bouncy;
	public int				health;
	public int				solid;

	// Use this for initialization
	void Start () {
		if (bouncy) {
			PhysicMaterial mat = Resources.Load ("Rubber", typeof(PhysicMaterial)) as PhysicMaterial;
			this.collider.material = mat;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bouncy) {
			PhysicMaterial mat = Resources.Load ("Rubber", typeof(PhysicMaterial)) as PhysicMaterial;
			this.collider.material = mat;
		}
	}

}
