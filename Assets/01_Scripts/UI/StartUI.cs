using System.Collections;
using System.Collections.Generic;
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
		print("asd");
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
