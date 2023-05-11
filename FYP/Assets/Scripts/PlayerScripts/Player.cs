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
    [SerializeField] GameObject dattacker;
    [SerializeField] Transform spawna;
    [SerializeField] GameObject angle;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject closest;
    [SerializeField] GameObject[] targets;

    [SerializeField] GameObject PA;
    [SerializeField] GameObject PD;
    [SerializeField] bool isGrounded;
    [SerializeField] bool enemyInRange = false;
    EnemyA1 EnemyA1;
    EnemyA2 EnemyA2;
    //EnemyB1 EnemyA3;
    //EnemyA4 EnemyA4;
    //EnemyA5 EnemyA5;
    //EnemyA6 EnemyA1;
    //EnemyA7 EnemyA1;

    Animator anim;
    Rigidbody rb;

    private void Awake()
    {
        PA.SetActive(true);
        PD.SetActive(false);

        anim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        // rb= GetComponent<Rigidbody>();
        cController= GetComponent<CharacterController>();
        EnemyA1 = enemy.GetComponent<EnemyA1>();
        EnemyA2 = enemy.GetComponent<EnemyA2>();

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
            SceneManager.LoadScene(9);  // to panel?
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

        //Walk(horInput, verInput);

        if (cController.isGrounded)
        {
            jumpCount = jumpCounter;
        }

        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Z) && timer >= attackSpeed && enemy != null && enemyInRange == true)
        {
            anim.SetTrigger("atk");
            timer = 0;

            if (PA.activeSelf)
            {            
                StartCoroutine(Atk());
                Debug.Log("A");
            }
            else
            {

                Instantiate(dattacker, shooter.transform.position, shooter.transform.rotation);
            }



            //timer = 0;
        }


        if (PA.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Alpha0) || Input.GetKeyUp(KeyCode.Keypad0))
            {
                PA.SetActive(false);
                PD.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) && !cController.isGrounded && jumpCount > 0)
            {
                jumpCount--;
                dirY = jumpForce;
                pGravity = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !cController.isGrounded)
            {
                pGravity = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Space) && !cController.isGrounded)
            {
                pGravity = 5;
            }

            dirY -= pGravity * Time.deltaTime;
            dir.y = dirY;
            cController.Move(dir * speed * Time.deltaTime);
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Alpha0) || Input.GetKeyUp(KeyCode.Keypad0))
            {
                PA.SetActive(true);
                PD.SetActive(false);

                pGravity = 5;
            }
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

                    oldDistance = currentDistance;
                }
            }
            oldDistance = Mathf.Infinity;
        }
        else if(other.gameObject.CompareTag("Boss") || targets != null)
        {
            enemyInRange = true;
            targets = GameObject.FindGameObjectsWithTag("Boss");
            closest = enemy;
            enemy = closest;
        }
    }

    IEnumerator Atk()
    {
        yield return new WaitForSeconds((float)0.8);
        Instantiate(attacker, shooter.transform.position, shooter.transform.rotation);

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

    void Walk(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        anim.SetBool("walk", walking);
    }

}
