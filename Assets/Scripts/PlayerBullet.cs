﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {

		// Get the bullet's current position
		Vector2 position = transform.position;

		// Compute the bullet's new position
		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

		// Update the bullet's position
		transform.position = position;

		// This is the top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		// If the bullet went outside the screen on top, destroy the bullet
		if(transform.position.y > max.y)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Detect collision of the player bullet with the enemy ship
		if(col.tag == "EnemyShipTag")
		{
			Destroy (gameObject);
		}
	}
}
