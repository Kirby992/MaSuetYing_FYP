using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy3;
    [SerializeField] Transform spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnW3", 16, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnW3()
    {
        int r = Random.Range(0, Enemy3.Length);
        Instantiate(Enemy3[r], spawnpoint.transform.position, Quaternion.identity);
    }
}
