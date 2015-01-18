using UnityEngine;
using System.Collections;

public class Metal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Material mat = Resources.Load ("Textures/Metal", typeof(Material)) as Material;
		this.gameObject.renderer.material = mat;
	}

}
