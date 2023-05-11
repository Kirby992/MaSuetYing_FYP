using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] arrows;


    float timeoutDuration = 2;
    float timeout = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeout > 0)
        {
            timeout -= Time.deltaTime;

            return;
        }

        SpawnArrows();

        timeout = timeoutDuration;

    }

    //move direction?

    public void SpawnArrows()
    {
        int r = Random.Range(0, arrows.Length);
        GameObject arrow = Instantiate(arrows[r], transform);
        arrow.transform.position = new Vector3(0, 0, 0);
    }

}
