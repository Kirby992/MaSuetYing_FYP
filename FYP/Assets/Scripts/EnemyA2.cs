using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyA2 : MonoBehaviour
{
    [SerializeField] int souls = 5;
    [SerializeField] float speed = 10;
    [SerializeField] float aspeed = 5;
    [SerializeField] float arange = 5;
    [SerializeField] float attack = 2;
    public float health, maxHealth = 5;
    

    //Skill2_BlowBurn s2;

    [SerializeField] Vector3 selfPosition;
    [SerializeField] Vector3 distanceDifference;
    [SerializeField] float oldDistance = Mathf.Infinity;
    [SerializeField] float currentDistance;

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject closest;
    [SerializeField] GameObject[] targetss;
    [SerializeField] GameObject[] targetssaes;

    [SerializeField] Transform target;
    [SerializeField] GameObject player;
    [SerializeField] GameObject aes;

    [SerializeField] float timer;
    [SerializeField] bool inRange = false;
    [SerializeField] bool isGround = false;
    Rigidbody rb;
    float dirX, dirZ;

    Player playerA;
    PAngle angle;
    Soul soul;
    EnemyA2 me;


    private void Start()
    {
        health = maxHealth;

        rb = GetComponent<Rigidbody>();

        player = GameObject.FindWithTag("Player");
        target = player.transform;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<Soul>().GetSouls(souls);
        }

        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);

        if (!isGround)
        {
            rb.AddForce(Vector3.down * 10);
        }

        //health bar
        //public float maxHealth = 100;
        //public float currentHealth = 100;
        //private float originalScale;

        //Vector3 tmpScale = gameObject.transform.localScale;
        //tmpScale.x = currentHealth / maxHealth * originalScale;
        //gameObject.transform.localScale = tmpScale;

        if (target == null)
        {
            player = GameObject.FindWithTag("Player");
            target = player.transform;
        }

        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);     
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < arange)
        {
            speed = 0;

            if (inRange == false && timer >= aspeed) // target == aes
            {
                aes = GameObject.FindWithTag("AEs");
                target = aes.transform;
                aes.GetComponent<PAngle>().health -= attack;
                timer = 0;
                //if (timer >= aspeed)
                //{
                //    angle.gameObject.GetComponent<PAngle>().Damaged(attack);
                //    timer = 0;
                //}
            }
            else if (inRange == true && timer >= aspeed) // && target == player
            {
                player = GameObject.FindWithTag("Player");
                target = player.transform;
                player.GetComponent<Player>().health -= attack;
                timer = 0;
                //if (inRange == true && timer >= aspeed)
                //{
                //    player.GetComponent<Player>().health -= 1;
                //    timer = 0;
                //}
            }
        }
        else
        {
            speed = 5;
        }
    }

    IEnumerator Attacker()
    {
        //GameObject closest = Instantiate(attacker, transform);
        //enemy.GetComponent<EnemyA2>().health -= attackDamage;
        player.GetComponent<Player>().health -= 1;
        Debug.Log("Player");
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("AEs"))
        {
            inRange = false;
            aes = GameObject.FindWithTag("AEs");
            target = aes.transform;          

            foreach (GameObject targetsaes in targetssaes)
            {
                distanceDifference = targetsaes.transform.position - selfPosition;
                currentDistance = distanceDifference.sqrMagnitude;
                if (currentDistance < oldDistance)
                {
                    closest = targetsaes;
                    aes = closest;
                    
                    oldDistance = currentDistance;
                }
            }
            oldDistance = Mathf.Infinity;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            player = GameObject.FindWithTag("Player");
            target = player.transform;

            targetss = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject targets in targetss)
            {
                inRange= true;
                distanceDifference = targets.transform.position - selfPosition;
                currentDistance = distanceDifference.sqrMagnitude;
                if (currentDistance < oldDistance)
                {
                    closest = targets;
                    player = closest;
                    //playerA = player.GetComponent<Player>();
                    
                    //StartCoroutine(Attacker());

                    if(inRange == true && timer >= aspeed)
                    {
                        player.GetComponent<Player>().health -= 1;
                        timer = 0;
                    }



                    oldDistance = currentDistance;
                }
            }
            oldDistance = Mathf.Infinity;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    inRange = false;
        //}
        //else if (other.gameObject.CompareTag("AEs"))
        //{
        //    inRange = false;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Attacker"))
        {
            health -= 3;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("AngleAttack"))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
        else if (other.gameObject.CompareTag("AEs"))
        {
            inRange = false;
        }
    }


    void Attack()
    {
        
    }

    public void Damaged(int damages)
    {
        health -= damages;

    }

    void Stunned()
    {
        
    }

}
