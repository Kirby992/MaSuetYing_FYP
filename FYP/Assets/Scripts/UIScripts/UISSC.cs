using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISSC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 2f;
                Debug.Log("2");
            }
            else if (Time.timeScale == 2)
            {
                Time.timeScale = 3f;
                Debug.Log("3");
            }
            else if (Time.timeScale == 3)
            {
                Time.timeScale = 1f;
                Debug.Log("1");
            }
        }
    }
}
