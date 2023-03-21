using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotBoss : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy1;
    [SerializeField] GameObject[] Enemy2;
    [SerializeField] GameObject[] Enemy3;

    [SerializeField] float hp, maxhp = 500;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0)
        {
            StartCoroutine(SpawnE1(5f));
        }

        if (timer > 5)
        {
            StartCoroutine(SpawnE1(3f));
            StartCoroutine(SpawnE2(10f));
        }

        if (timer > 15)
        {
            StartCoroutine(SpawnE1(1f));
            StartCoroutine(SpawnE2(5f));
        }

        if (timer > 30)
        {
            StartCoroutine(SpawnE1(1f));
            StartCoroutine(SpawnE2(5f));
            StartCoroutine(SpawnE3(15f));
        }

        if (timer > 30)
        {
            StartCoroutine(SpawnE1(1f));
            StartCoroutine(SpawnE2(3f));
            StartCoroutine(SpawnE3(10f));
        }


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

    IEnumerator SpawnE3(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        int r = Random.Range(0, Enemy3.Length);
        Instantiate(Enemy3[r]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hp < 1)
        {

            SceneManager.LoadScene(3);
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
