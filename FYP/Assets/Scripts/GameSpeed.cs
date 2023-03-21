using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    [SerializeField] Button speed1;
    [SerializeField] Button speed2;
    [SerializeField] Button speed3;

    [SerializeField] bool s1 = true;
    [SerializeField] bool s2 = false;
    [SerializeField] bool s3 = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (s1)
            {
                speed1.gameObject.SetActive(false);


                s1 = false;
                s2 = true;
                s3 = false;
            }
            else if (s2)
            {
                s1 = false;
                s2 = false;
                s3 = true;
            }
            else
            {
                s1 = true;
                s2 = false;
                s3 = false;
            }
        }
    }

    public void Speed1()
    {
        Time.timeScale = 1f;
    }

    public void Speed2()
    {
        Time.timeScale = 2f;
    }

    public void Speed3()
    {
        Time.timeScale = 3f;
    }







}
