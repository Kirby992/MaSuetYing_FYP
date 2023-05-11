using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEngine.GraphicsBuffer;

public class EnemyA1 : MonoBehaviour
{
    [SerializeField] int souls;
    [SerializeField] float speed;
    [SerializeField] float attack;
    [SerializeField] float aspeed;
    [SerializeField] float arange;
    public float maxHealth, health, respeed, reattack;

    //Skill2_BlowBurn s2;

    [SerializeField] Vector3 selfPosition;
    [SerializeField] Vector3 distanceDifference;
    [SerializeField] float oldDistance = Mathf.Infinity;
    [SerializeField] float currentDistance;

    //[SerializeField] GameObject enemy;
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


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        respeed = speed;
        reattack = attack;

        rb = GetComponent<Rigidbody>();

        player = GameObject.FindWithTag("Player");
        target = player.transform;
        //aes = GameObject.FindWithTag("AEs");


    }

    // Update is called once per frame
    void Update()
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
            rb.AddForce(Vector3.down * 50);
        }

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
            }
            else if (inRange == true && timer >= aspeed) // && target == player
            {
                player = GameObject.FindWithTag("Player");
                target = player.transform;                
                player.GetComponent<Player>().health -= attack;
                timer = 0;  
            }          
        }
        else
        {           
            speed = respeed;
        }
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
                    
                    //EnemyA2 = enemy.GetComponent<EnemyA2>();
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
                distanceDifference = targets.transform.position - selfPosition;
                currentDistance = distanceDifference.sqrMagnitude;
                if (currentDistance < oldDistance)
                {
                    closest = targets;
                    player = closest;


                    oldDistance = currentDistance;
                }
            }
            oldDistance = Mathf.Infinity;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
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
        }

        if (collision.gameObject.CompareTag("AngleAttack"))
        {
            health -= 1;
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

    public void Damaged(float damages)
    {
        health -= damages;

        

    }



}
