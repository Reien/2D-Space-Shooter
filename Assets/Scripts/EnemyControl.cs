﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

	float speed;
	public GameObject ExplosionPrefab;

	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {

		// Get the enemy current position
		Vector2 position = transform.position;

		// Compute the enemy new position
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

		// Update the enemy position
		transform.position = position;

		// Bottom-left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, -0.1f));

		// If the enemy went outside the screen on the bottom, destroy the enemy
		if(transform.position.y < min.y)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Detect collision of the enemy ship with the player ship, or with a player bullet
		if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
		{
			PlayExplosion ();

			Destroy (gameObject);
		}
	}

	// Function to instantiate an explosion
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionPrefab);

		// Set the position of the explosion
		explosion.transform.position = transform.position;
	}
}
