using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using gunggme;
using TMPro;


public class UIManager : Singelton<UIManager>
{
	[SerializeField] private AudioSource mainAudio;

	[SerializeField] private GameObject escPanel;
	[SerializeField] private GameObject rankingPanel;
	[SerializeField] private GameObject gameOverPanel;

	[SerializeField] private TextMeshProUGUI timeTxt;
	[SerializeField] private TextMeshProUGUI recordTimeTxt;

	private bool isEsc;

	private float time = 0;
	private string min = string.Empty;
	private string sec = string.Empty;

	private void Start()
	{
		time = 0;
	}

	private void Update()
	{
		if(escPanel != null)
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

		time += Time.deltaTime;
		if(timeTxt != null)
			TimeTxt((int)time);
	}

	public void Mute(bool isMute)
	{
		mainAudio.mute = isMute;
	}

	public void SceneChange(int num)
	{
		Time.timeScale = 1;
		DestroyObj();
		SpawnManager.Instance.DestroyObj();
		SceneManager.LoadScene(num);
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
		min = (time / 60).ToString();
		sec = (time % 60).ToString();

		if(int.Parse(min) < 10)
			min = "0" + min;
		if(int.Parse(sec) < 10)
			sec = "0" + sec;

		timeTxt.text = $"{min} : {sec}";
	}

	public void GameOverPanel()
	{
		recordTimeTxt.text = $"{min} : {sec}";
		timeTxt.text = $"{min} : {sec}";
		gameOverPanel.transform.DOMoveY(0, 1);
		Sequence seq = DOTween.Sequence();
		seq.Append(gameOverPanel.transform.DOMoveY(0, 1));
		seq.Insert(1f, DOTween.To(() => 0f, x => Time.timeScale = 0, 0f, 0f));
		timeTxt.text = $"{min} : {sec}";
	}
}
