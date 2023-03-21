using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy2;
    [SerializeField] Transform spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnW2", 12, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnW2()
    {
        int r = Random.Range(0, Enemy2.Length);
        Instantiate(Enemy2[r], spawnpoint.transform.position, Quaternion.identity);
    }
}
