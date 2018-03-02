using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	float rotSpeed = 180f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Returns a FLOAT from -1.0 to +1.0
		//Input.GetAxis ("Vertical");

		// Moving the ship.
		Vector3 pos = transform.position;
		pos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		pos.x += Input.GetAxis ("Horizontal") * maxSpeed * Time.deltaTime;
		transform.position = pos;

		// Rotating the ship.

		/*
		// Grab our rotation quaternion
		Quaternion rot = transform.rotation;

		// Grab the Z euler angle
		float z = rot.eulerAngles.z;

		// Change the Z angle based on input
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;

		// Recreate the quaternion
		rot = Quaternion.Euler (0, 0, z);

		// Feed the quaternion into our rotation
		transform.rotation = rot;
		*/
	}
}
