using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Skill3_HealthMias : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] Image cooldown;
    float reloaded = 20;
    float reload = 0;
    bool canClick = true;
    [SerializeField] int souls;
    [SerializeField] int price = 50;
    Soul soul;

    Player php;
    PAngle hp;
    [SerializeField] float buffhp = 10;
    [SerializeField] int time = 10;

    bool timeon = false;


    private void Start()
    {
        cooldown.fillAmount = 0;

        php = GameObject.Find("PA").GetComponent<Player>();
        //hp = GameObject.Find("pAngle").GetComponent<PAngle>();

        soul = FindObjectOfType<Soul>();

        //hp = GameObject.FindWithTag("pAngle").GetComponent<PAngle>();
        //PAngle hp = GetComponent<PAngle>();
        //hp.health += 10;


        //List<Player> players = GameObject.FindGameObjectsWithTag("Player").Select(obj => obj.GetComponent<Player>()).ToList();



    }

    void Cooling()
    {
        reload -= Time.deltaTime;

        if (reload < 0)
        {
            canClick = false;
            cooldown.fillAmount = 0;
        }
        else
        {
            cooldown.fillAmount = reload / reloaded;
        }
    }

    private void Update()
    {
        if (canClick)
        {
            Cooling();
        }

        souls = soul.soul;
        if (souls >= price)
        {
            if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
            {
                ASkill3();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                Clicked(btn.colors.pressedColor);
                btn.onClick.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp(KeyCode.Alpha3))
            {
                Clicked(btn.colors.normalColor);
            }

        }
    }

    public void ASkill3()
    {
        if (souls >= price)
        {
            if (canClick)
            {

            }
            else
            {
                canClick = true;
                Skill_3();
                reload = reloaded;
                soul.UseSoul(price);
            }
        }


    }

    void Skill_3()
    {
        hp = GameObject.FindWithTag("AEs").GetComponent<PAngle>();

        php.health += buffhp;

        hp.health += buffhp;
        hp.maxHealth += buffhp;
        timeon = true;

        if (timeon)
        {
            StartCoroutine(BuffingTime());
        }
        else
        {
            StopCoroutine(BuffingTime());
        }
    }

    IEnumerator BuffingTime()
    {
        yield return new WaitForSeconds(time);
        Buffed();
    }

    void Buffed()
    {
        hp.maxHealth -= buffhp;
        timeon = false;
    }

    void Clicked(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, btn.colors.fadeDuration, true, true);
    }



    // Mias?

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyA1>(out EnemyA1 enemyComponet))
        {
            enemyComponet.Damaged(3);
        }
    }







}
