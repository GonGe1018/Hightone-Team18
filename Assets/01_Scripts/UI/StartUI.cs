using System.Collections;
using System.Collections.Generic;
using BackEnd;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUI : MonoBehaviour
{
	[SerializeField] private GameObject nickPanel;
	[SerializeField] private TMP_InputField nickInput;

	public void SceneChange(int num)
	{
		SceneManager.LoadScene(num);
	}

	public void NicknameSetting()
	{
		string nick = nickInput.text;
		var bro = Backend.BMember.CreateNickname(nick);

		if (bro.GetStatusCode() != "204")
		{
			// todo 사용이 불가능하드는 텍스트 생성
			return;
		}
		nickPanel.SetActive(false);
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
}
