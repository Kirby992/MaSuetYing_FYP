using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy1;
    [SerializeField] Transform spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnW1", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnW1()
    {
        int r = Random.Range(0, Enemy1.Length);
        Instantiate(Enemy1[r], spawnpoint.transform.position, Quaternion.identity);
    }

}
