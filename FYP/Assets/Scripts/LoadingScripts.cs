using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Loading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Loading(int playscene)
    {
        SceneManager.LoadScene(playscene);
        yield return new WaitForSeconds(2f);
    }


}
