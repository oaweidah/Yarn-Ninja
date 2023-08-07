using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls_Lore : MonoBehaviour
{
    public void OpenControlScreen()
    {
        SceneManager.LoadScene("Lore & Controls");
    }
}
