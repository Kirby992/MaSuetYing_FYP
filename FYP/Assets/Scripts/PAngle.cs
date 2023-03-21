using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PAngle : MonoBehaviour
{
    [SerializeField] Vector3 selfPosition;
    [SerializeField] Vector3 distanceDifference;
    [SerializeField] float oldDistance = Mathf.Infinity;
    [SerializeField] float currentDistance;

    [SerializeField] float speed = 10;
    [SerializeField] float aspeed = 2;
    [SerializeField] float arange = 5;
    [SerializeField] float attack = 1;
    public float health, maxHealth = 10;
    public int buffer;

    [SerializeField] GameObject attacker;
    [SerializeField] Transform shooter;
    [SerializeField] Transform myTansform;

    [SerializeField] Transform target;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject closest;
    [SerializeField] GameObject[] targetss;
    [SerializeField] GameObject[] targets;

    [SerializeField] float timer;
    [SerializeField] bool inRange;
    [SerializeField] bool isGround = false;
    Rigidbody rb;
    float dirX, dirZ;

    EnemyA1 EnemyA1;
    EnemyA2 EnemyA2;

    //public static object extrahp { get; internal set; }

    private void Start()
    {
        health = maxHealth;

        rb = GetComponent<Rigidbody>();

        enemy = GameObject.FindWithTag("Enemy");
        target = enemy.transform;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);

        //if (!isGround)
        //{
        //   rb.AddForce(Vector3.down * 10);
        //}


        if(inRange)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            target = enemy.transform;
        }
        else
        {
            boss = GameObject.FindGameObjectWithTag("Boss");
            target = boss.transform;
        }




        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < arange)
        {
            speed = 0;

            if (timer >= aspeed && inRange)
            {
                enemy = GameObject.FindWithTag("Enemy");
                target = enemy.transform;
                Instantiate(attacker, shooter.transform.position, shooter.transform.rotation);
                timer = 0;
            }
            else if(timer >= aspeed && !inRange)
            {
                boss = GameObject.FindWithTag("Boss");
                target = boss.transform;
                Instantiate(attacker, shooter.transform.position, shooter.transform.rotation);     
                timer = 0;

                //boss.GetComponent<Boss>().health -= attack;

            }
        }
        else
        {
            speed = 10;
        }

        //if (enemy != null && enemyInRange == true)
        //{
        //    StartCoroutine(Attacker());
        //}


    }

    //enemy.GetComponent<EnemyA2>().health -= attackDamage;
    IEnumerator Attacker()
    {
        inRange = false;
        Instantiate(attacker, transform);
        yield return new WaitForSeconds(1);
        inRange = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            inRange = true;
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject target in targets)
            {
                distanceDifference = target.transform.position - selfPosition;
                currentDistance = distanceDifference.sqrMagnitude;
                if (currentDistance < oldDistance)
                {
                    closest = target;
                    enemy = closest;
                    //EnemyA1 = enemy.GetComponent<EnemyA1>();
                    //EnemyA2 = enemy.GetComponent<EnemyA2>();

                    oldDistance = currentDistance;
                }
            }
            oldDistance = Mathf.Infinity;
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            inRange = false;
            boss = GameObject.FindWithTag("Boss");
            target = boss.transform;

            targetss = GameObject.FindGameObjectsWithTag("Boss");
            foreach (GameObject targets in targetss)
            {
                inRange = true;
                distanceDifference = targets.transform.position - selfPosition;
                currentDistance = distanceDifference.sqrMagnitude;
                if (currentDistance < oldDistance)
                {
                    closest = targets;
                    boss = closest;
                    //playerA = player.GetComponent<Player>();

                    //StartCoroutine(Attacker());

                    //if (inRange == true && timer >= aspeed)
                    //{
                    //    boss.GetComponent<Boss>().health -= 1;
                    //    timer = 0;
                    //}



                    oldDistance = currentDistance;
                }
            }
            oldDistance = Mathf.Infinity;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            inRange = false;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

        public void Damaged(float damages)
    {
        health -= damages;


    }
}
