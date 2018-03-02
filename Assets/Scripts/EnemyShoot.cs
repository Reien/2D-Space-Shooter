using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject EnemyBulletPrefab;

	// Use this for initialization
	void Start () {
		// Fire an enemy bullet after 1 second
		Invoke ("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Function to fire an enemy bullet
	void FireEnemyBullet()
	{
		// Get a reference to the player's ship
		GameObject playerShip = GameObject.Find ("Player");

		// If player is not dead
		if(playerShip != null)
		{
			// Instantiate an enemy bullet
			GameObject bullet = (GameObject)Instantiate (EnemyBulletPrefab);

			// Set the bullet's initial position
			bullet.transform.position = transform.position;

			// Compute the bullet's direction towards the player's ship
			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			// Set the bullet's direction
			bullet.GetComponent <EnemyBullet> ().SetDirection (direction);
		}
	}
}
