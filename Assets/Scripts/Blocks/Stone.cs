﻿using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Material mat = Resources.Load ("Textures/Stone", typeof(Material)) as Material;
		this.gameObject.renderer.material = mat;
	}

}
