using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Loading : MonoBehaviour
{
    //Skill1_Spawn s1;

    float delay = 0;
    bool canClick = true;

    public UnityEvent<float> reloading;


    // Start is called before the first frame update
    void Start()
    {
        reloading?.Invoke(delay);
    }

    // Update is called once per frame
    void Update()
    {
        if (canClick == false)
        {
            delay -= Time.deltaTime;
            //reloading?.Invoke(delay / s1.reload);

            if(delay <= 0)
            {
                canClick= true;
            }
        }
    }

    public void Load()
    {
        if (canClick)
        {
            canClick= false;
            //delay = s1.reload;
        }
    }


}
