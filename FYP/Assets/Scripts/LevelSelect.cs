using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] btnlvl;
    // Start is called before the first frame update
    void Start()
    {
        int levelat = PlayerPrefs.GetInt("levelat", 2);

        for (int i = 0; i < btnlvl.Length; i++)
        {
            if(i + 2 > levelat)
            {
                btnlvl[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
