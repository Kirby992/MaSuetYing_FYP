using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gostage : MonoBehaviour
{
    [SerializeField] int num;


    public void Nextstage()
    {
        SceneManager.LoadScene(num);
        //StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(num);

    }
}
