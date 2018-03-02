using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject playButton;
	public GameObject playerShip;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () {
		GMState = GameManagerState.Opening;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
