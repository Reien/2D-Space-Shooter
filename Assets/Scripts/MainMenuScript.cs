using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider loadingSlider;
	public TextMeshProUGUI progressText;

	public void PlayGame(string name)
	{
		StartCoroutine(LoadingAsynchronously(name));
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}

	IEnumerator LoadingAsynchronously (string name)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(name);

		loadingScreen.SetActive(true);

		while(!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / 0.9f);

			loadingSlider.value = progress;
			progressText.text = progress * 100  + "%";

			yield return null;
		}
	}
}
