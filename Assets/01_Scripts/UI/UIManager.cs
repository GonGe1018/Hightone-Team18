using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : Singltone<UIManager>
{
	[SerializeField] private AudioSource mainAudio;

	[SerializeField] private GameObject escPanel;
	[SerializeField] private GameObject rankingPanel;

	private bool isEsc;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isEsc = !isEsc;
			if(isEsc)
			{
				Time.timeScale = 0;
				escPanel.SetActive(true);
			}
			else
			{
				BackToGame();
			}
		}
	}

	public void Mute(bool isMute)
	{
		mainAudio.mute = isMute;
	}

	public void SceneChange(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void BackToGame() // esc Á¾·á
	{
		escPanel.SetActive(false);
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void SetActiveTrue(GameObject gameObject)
	{
		gameObject.SetActive(true);
	}

	public void SetActiveFalse(GameObject gameObject)
	{
		gameObject.SetActive(false);
	}

	public void ButtonHover()
	{
		transform.localScale = Vector3.one * 1.05f;
	}

	public void ButtonResetScale()
	{
		transform.localScale = Vector3.one;
	}
}
