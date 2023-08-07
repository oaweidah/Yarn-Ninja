using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("Level Select");
    }
	
	public void QuitGame ()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}
