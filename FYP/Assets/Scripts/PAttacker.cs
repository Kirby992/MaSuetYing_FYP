using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PAttacker : MonoBehaviour
{
    //[SerializeField] int attackDamage;
    Rigidbody rb;
    int speed = 20;

    [SerializeField] Transform target;
    [SerializeField] GameObject enemy;
    Vector3 dir;
    float dirX, dirY, dirZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GameObject.FindWithTag("Enemy");
        target = enemy.transform;
        dir = (enemy.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector3(dir.x, dir.x, dir.z);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rb.velocity = new Vector3(dirX, dirY, dirZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }

}
