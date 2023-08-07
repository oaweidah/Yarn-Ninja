using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
	public Button[] lvlButtons;
	
    // Start is called before the first frame update
    void Start()
    {
        int atLevel = PlayerPrefs.GetInt("atLevel", 2);
		
		for (int i = 0; i < lvlButtons.Length; i++)
		{
			if (i + 2 > atLevel)
				lvlButtons[i].interactable = true;
		}
    }

}
