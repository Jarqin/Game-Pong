using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Update () 
	{
		Time.timeScale = 0;
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Time.timeScale = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
