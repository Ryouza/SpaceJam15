using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Heart : MonoBehaviour {
	GameObject mc;
	public Image image;
	private int size = 5;
	public List<Image> array = new List<Image> ();
	Health life;

	// Use this for initialization
	void Start () {
		mc = GameObject.Find ("MC");
		Image new_obj;
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
		for (int i = 0; i < size; i++) {
			array.Add (image);
			new_obj = Instantiate(image) as Image;
			new_obj.transform.SetParent(this.gameObject.transform, false);
			new_obj.transform.position = new Vector3(- width / 2 + new_obj.rectTransform.rect.width * (i + 1), height, 0);
		}
		life = mc.GetComponent< Health > ();
	}

	void Update () {
		if (mc != null) {
			if (life.health < array.Count) {
				int diff = array.Count - (int)life.health;
				for (int i = diff; i > 0; i--) {
					GameObject target = (transform.GetChild(array.Count - 1)).gameObject;
					Destroy(target);
					array.RemoveAt(array.Count - 1);
				}
			}
		} else {
			for (int i = array.Count; i > 0; i--) {
				GameObject target = (transform.GetChild(array.Count - 1)).gameObject;
				Destroy(target);
				array.RemoveAt(array.Count - 1);
			}
		}
	}
}
