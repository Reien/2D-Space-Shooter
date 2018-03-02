using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	// Bullet Speed
	float speed;

	// The direction of the bullet
	Vector2 _direction;

	// To know when the bullet direction is set
	bool isReady;

	// Set default values in Awake function
	void Awake()
	{
		speed = 5f;
		isReady = false;
	}

	// Use this for initialization
	void Start () {
		
	}

	//Function to set the Bullet's direction
	public void SetDirection(Vector2 direction)
	{
		// Set the direction normalized, to get a unit vector
		_direction = direction.normalized;

		isReady = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(isReady)
		{
			// Get the Bullet's current position
			Vector2 position = transform.position;

			// Compute the Bullet's new position
			position += _direction * speed * Time.deltaTime;

			// Update the Bullet's position
			transform.position = position;

			// Next we need to remove the bullet from our game
			// if the bullet goes outside the screen

			// Bottom-left point of the screen
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

			// Top-right point of the screen
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

			// If the Bullet goes outside the screen, then destroy it
			if((transform.position.x < min.x) || (transform.position.x > max.x) ||
			   (transform.position.x < min.y) || (transform.position.x > max.y))
			{
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Detect the collision of the enemy bullet with the player ship
		if(col.tag == "PlayerShipTag")
		{
			Destroy (gameObject);
		}
	}
}
