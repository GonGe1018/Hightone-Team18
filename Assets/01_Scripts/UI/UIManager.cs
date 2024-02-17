using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private AudioSource mainAudio;
	[SerializeField] private GameObject escPanel;

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

	public void BackToStart()
	{
		SceneManager.LoadScene(0); // 시작 씬 이동
	}

	public void BackToGame() // esc 종료
	{
		escPanel.SetActive(false);
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
