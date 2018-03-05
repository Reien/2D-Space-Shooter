﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene("Main");
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
