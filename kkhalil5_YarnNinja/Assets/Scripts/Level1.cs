using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Level 1");
    }
}
