using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class XSkills : MonoBehaviour
{

    [SerializeField] Button as1;
    [SerializeField] Button as2;
    [SerializeField] Button as3;
    [SerializeField] Button as4;

    [SerializeField] GameObject asummon;
    [SerializeField] int health, maxhealth;
    [SerializeField] GameObject allEnemy;
    [SerializeField] GameObject angles;

    [SerializeField] string Enemy;

    // Start is called before the first frame update
    void Awake()
    {
        as1 = GetComponent<Button>();
        as2 = GetComponent<Button>();
        as3 = GetComponent<Button>();
        as4 = GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
        {
            //EventSystem.current.SetSelectedGameObject(this.gameObject);
            ASkill1();
        }



        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
        {
            StartCoroutine(ASkill3());
        }
    }


    public void ASkill1()
    {
        Instantiate(asummon);
    }

    public void ASkill_2()
    {
        StartCoroutine(ASkill2());
    }


    public IEnumerator ASkill2()
    {
        //Player heal = new();
        //heal.health += 10;


        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
        {
            GameObject[] aes = GameObject.FindGameObjectsWithTag("AEs");
            foreach (GameObject ae in aes)
            {
                health += 10;
                maxhealth += 10;
                yield return new WaitForSeconds(5);
            }
        }


    }

    public IEnumerator ASkill3()
    {
        //yield return new WaitForSeconds(time);

        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject es in allEnemy)
        {
            es.GetComponent<Rigidbody>().velocity = Vector3.zero; // Or true
            yield return new WaitForSeconds(5);
        }

    }


    public void OnCollisionStay(Collision collision)
    {
        if ((Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4)) && collision.collider.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(angles);
        }
    }

}

