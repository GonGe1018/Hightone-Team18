using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class UIManager : Singelton<UIManager>
{
	[SerializeField] private AudioSource mainAudio;

	[SerializeField] private GameObject escPanel;
	[SerializeField] private GameObject rankingPanel;

	[SerializeField] private TextMeshProUGUI timeTxt;

	private bool isEsc;

	private float time = 0;

	private void Start()
	{
		time = 0;
	}

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

		time += Time.deltaTime;
		TimeTxt((int)time);
	}

	public void Mute(bool isMute)
	{
		mainAudio.mute = isMute;
	}

	public void SceneChange(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void BackToGame() // esc ����
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

	public void TimeTxt(int time)
	{
		string min = (time / 60).ToString();
		string sec = (time % 60).ToString();

		if(int.Parse(min) < 10)
			min = "0" + min;
		if(int.Parse(sec) < 10)
			sec = "0" + sec;

		timeTxt.text = $"{min} : {sec}";
	}
}
