using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public GameObject PlayerBulletGO;
	public GameObject bulletPosition;	
	public GameObject ExplosionPrefab;
		
	public Text LivesTextUI;

	const int MaxLives = 3;
	int lives;

	public float speed;

	public float FireRate;
	private float canFire;

	public void Awake()
	{
		lives = MaxLives;

		canFire = FireRate;

		LivesTextUI.text = lives.ToString ();

        gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		FireBullets();

		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y).normalized;

		// Call the function that computes and sets the player's position
		Move (direction);
	}

	void Move(Vector2 direction)
	{
		// Find the screen limits to the player's movement (left, right, top, bottom edges)
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		// Subtract the player sprite half width
		max.x -= 0.350f;
		// Add the player sprite half width
		min.x += 0.350f;

		// Subtract the player sprite half height
		max.y -= 0.285f;
		// Add the player sprite half height
		min.y += 0.285f;

		// Get the player's current position
		Vector2 pos = transform.position;

		// Calculate the new position
		pos += direction * speed * Time.deltaTime;

		// Make sure the new position is not outside the screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		// Update the player's position
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Detect collision of the player ship with an enemy ship, or with an enemy bullet
		if(( col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		{
			PlayExplosion ();

			lives--;
			LivesTextUI.text = lives.ToString();

            if (lives == 0)
            {
                gameObject.SetActive(false);
            }
		}
	}

	// Function to instantiate an explosion
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionPrefab);

		// Set the position of the explosion
		explosion.transform.position = transform.position;
	}

	void FireBullets()
	{
			// Fire bullets when spacebar is pressed
		if(Input.GetButton("Jump") && canFire <= 0)
		{
			// Instantiate the bullet
			GameObject bullet = (GameObject)Instantiate(PlayerBulletGO);
			bullet.transform.position = bulletPosition.transform.position;
			canFire = FireRate;
		}
		else
		{
			canFire -= Time.deltaTime;
		}
	}
}
