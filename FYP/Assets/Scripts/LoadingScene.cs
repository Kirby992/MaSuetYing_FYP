using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScripts : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] string stageName;
    [SerializeField] float time;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > delay)
        {
            SceneManager.LoadScene(stageName);
        }
    }
}
