using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public float xMargin = 1f; // the amount the MC can move before camera follows
	public float yMargin = 1f;
	public float xSmooth = 8f; // how quickly the camera follows once the margin is crossed
	public float ySmooth = 8f;
	public Vector2 maxXandY; // the max x and y coordinate the camera can have.
	public Vector2 minXandY;

	private Transform player;  // reference to the player's transform

	void Awake() {
		// Setting up the reference
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	bool CheckXMargin() {
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin
		return Mathf.Abs (transform.position.x - player.position.x) > xMargin;
	}

	bool CheckYMargin() {
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin
		return Mathf.Abs (transform.position.y - player.position.y) > yMargin;
	}

	void FixedUpdate() {
		TrackPlayer ();
	}

	void TrackPlayer() {
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
	
		// If the player has moved beyond the x margin...
		if (CheckXMargin ()) {
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position
			targetX = Mathf.Lerp (transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		}
		
		if (CheckYMargin ()) {
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position
			targetY = Mathf.Lerp (transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		}

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum
		targetX = Mathf.Clamp (targetX, minXandY.x, maxXandY.x);
		targetY = Mathf.Clamp (targetY, minXandY.y, maxXandY.y);

		//Set the camera's position to the target position with the same z component
		transform.position = new Vector3 (targetX, targetY, transform.position.z);

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
















