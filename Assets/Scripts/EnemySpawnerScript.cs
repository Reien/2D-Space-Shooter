using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject EnemyPrefab;

	public float maxSpawnRateInSeconds = 0f;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		// Increase spawn rate every 30 seconds
		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy()
	{
		// Bottom-left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0.05f, 0));

		// Top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (0.95f, 1));

		// Instantiate/Spawn an enemy
		GameObject Enemy = (GameObject)Instantiate (EnemyPrefab);
		Enemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		// Schedule when to spawn next enemy
		ScheduleNextEnemySpawn ();
	}

	void ScheduleNextEnemySpawn()
	{
		float spawnInXSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			// Pick a number between 1 and maxSpawnRateInSeconds
			spawnInXSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		}
		else
			spawnInXSeconds = 1f;

		Invoke ("SpawnEnemy", spawnInXSeconds);
	}

	// Function to increase the difficulty of the game
	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}
}
