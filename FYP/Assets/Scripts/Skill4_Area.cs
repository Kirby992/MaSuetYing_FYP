using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill4_Area : MonoBehaviour
{
    [SerializeField] int count = 0;
    [SerializeField] GameObject angle;
    [SerializeField] Transform spawnpt;
    Skill4_PuriSilence s4bool;

    public List<GameObject> allenemy = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //spawnpt = transform;

        //*************

        s4bool = FindObjectOfType<Skill4_PuriSilence>();

        //*************


        //s4bool = GetComponent<Skill4_PuriSilence>();
        //Skill4_PuriSilence s4bool = gameObject.GetComponent<Skill4_PuriSilence>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s4bool.spawning)
        {
            foreach (GameObject obj in allenemy.ToList())
            {
                allenemy.Remove(obj);
                Destroy(obj);
                Instantiate(angle, spawnpt.transform.position, spawnpt.transform.rotation);
                s4bool.spawning = false;
                count -= count;
            }
        }


    }

    public void ToSkill4()
    {
            foreach (GameObject obj in allenemy.ToList())
            {
                allenemy.Remove(obj);
                GameObject.Destroy(obj);
                Instantiate(angle, spawnpt.position, Quaternion.identity);
            }       
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            count += 1;
            allenemy.Add(col.gameObject);
            Debug.Log("yyy");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            count -= 1;
            allenemy.Remove(col.gameObject);
            Debug.Log("nnn");

        }
    }



}
