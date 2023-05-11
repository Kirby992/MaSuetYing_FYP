using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBgm : MonoBehaviour
{
    private static UIBgm bgm;

    // Start is called before the first frame update
    void Awake()
    {
        if(bgm == null)
        {
            bgm = this;
            DontDestroyOnLoad(bgm);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
