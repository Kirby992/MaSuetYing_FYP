using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAAttackRange : MonoBehaviour
{
    [SerializeField] GameObject attacker;
    [SerializeField] Transform spawnp;
    [SerializeField] int speed = 10;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        bool shoot = (Input.GetKey(KeyCode.Z));

        if(shoot)
        {
            var b = Instantiate(attacker, spawnp.transform.position, spawnp.transform.rotation);
            b.GetComponent<Rigidbody>().velocity = spawnp.forward * speed;
            //GameObject at = Instantiate(attacker, spawnp.transform.position, spawnp.transform.rotation);
            //at.transform.localScale = transform.localScale;
            //Instantiate(attacker, transform);
        }
    }
}
