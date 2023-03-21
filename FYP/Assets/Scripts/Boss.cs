using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy1;
    [SerializeField] GameObject[] Enemy2;
    [SerializeField] GameObject[] Enemy3;

    public float health, maxhp = 500;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }

        //if (timer > 0)
        //{
        //    StartCoroutine(SpawnE1(5f));
        //}

        //if (timer > 5)
        //{
        //    StartCoroutine(SpawnE1(3f));
        //    StartCoroutine(SpawnE2(10f));
        //}


    }

    IEnumerator SpawnE1(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        int r = Random.Range(0, Enemy1.Length);
        Instantiate(Enemy1[r]);

    }

    IEnumerator SpawnE2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        int r = Random.Range(0, Enemy2.Length);
        Instantiate(Enemy2[r]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Attacker"))
        {
            health -= 3;
        }

        if (collision.gameObject.CompareTag("AngleAttack"))
        {
            health -= 1;
        }

    }

    void DestroyAll(string Enemy)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }

    }

}