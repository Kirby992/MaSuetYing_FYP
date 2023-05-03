using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 playerPosition;
    [SerializeField] Vector3 distanceDifference;
    [SerializeField] float oldDistance = Mathf.Infinity;
    [SerializeField] float currentDistance;
    [SerializeField] float timer;

    public float health, maxHealth = 100;
    [SerializeField] int attackSpeed = 2;
    [SerializeField] int attackDamage = 3;
    [SerializeField] int speed = 10;

    CharacterController cController;
    [SerializeField] float rotationSpeed;
    [SerializeField] int pGravity = 5;
    [SerializeField] int jumpForce = 3;
    [SerializeField] int jumpCounter = 3;
    [SerializeField] int jumpCount;
    float dirY;
    //bool jumpAgain = false;

    [SerializeField] Transform shooter;
    [SerializeField] GameObject attacker;
    [SerializeField] Transform spawna;
    [SerializeField] GameObject angle;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject closest;
    [SerializeField] GameObject[] targets;

    [SerializeField] bool isGrounded;
    [SerializeField] bool enemyInRange = false;
    EnemyA1 EnemyA1;
    EnemyA2 EnemyA2;
    //EnemyB1 EnemyA3;
    //EnemyA4 EnemyA4;
    //EnemyA5 EnemyA5;
    //EnemyA6 EnemyA1;
    //EnemyA7 EnemyA1;

    Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        // rb= GetComponent<Rigidbody>();
        cController= GetComponent<CharacterController>();

        
        attacker.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }

        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horInput, 0, verInput);
        cController.Move(dir * speed * Time.deltaTime);

        if (dir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


        if (cController.isGrounded)
        {
            jumpCount = jumpCounter;
        }
        
        
        if(Input.GetKeyUp(KeyCode.Space) && !cController.isGrounded && jumpCount > 0)
            {
            jumpCount--;
            dirY = jumpForce;
            pGravity = 5;
            }
        else if (Input.GetKeyDown(KeyCode.Space) && !cController.isGrounded)
        {
            pGravity= 1;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !cController.isGrounded)
        {
            pGravity= 5;
        }

            dirY -= pGravity * Time.deltaTime;
        dir.y = dirY;
        cController.Move(dir * speed * Time.deltaTime);


        timer += Time.deltaTime;

        if (timer >= attackSpeed && enemy != null && enemyInRange == true && Input.GetKey(KeyCode.Z))
        {
            Instantiate(attacker, shooter.transform.position, shooter.transform.rotation);
            timer = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }


        if (other.gameObject.CompareTag("Enemy") || targets != null)
        {
            enemyInRange = true;
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject target in targets)
            {
                distanceDifference = target.transform.position - playerPosition;
                currentDistance = distanceDifference.sqrMagnitude;
                if (currentDistance < oldDistance)
                {
                    closest= target;
                    enemy = closest;
                    EnemyA1 = enemy.GetComponent<EnemyA1>();
                    EnemyA2 = enemy.GetComponent<EnemyA2>();

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
            enemy = null;
            closest = null;
            enemyInRange = false;
        }
    }

    public void Heal(float heal)
    {
        health += heal;
    }
}
