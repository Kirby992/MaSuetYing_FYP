using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Skill2_BlowBurn : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] Image cooldown;
    float reloaded = 10;
    float reload = 0;
    bool canClick = true;
    [SerializeField] int souls;
    [SerializeField] int price = 20;
    Soul soul;

    //int damages = 1;
    [SerializeField] int speed = 0;
    //[SerializeField] Vector3 dir;

    int time = 5;
    bool timeon = false;

    private void Start()
    {
        cooldown.fillAmount = 0;

        soul = FindObjectOfType<Soul>();

        //dir = Vector3.zero;

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
            if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
            {
                ASkill2();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                Clicked(btn.colors.pressedColor);
                btn.onClick.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.Alpha2))
            {
                Clicked(btn.colors.normalColor);
            }

        }
    }

    public void ASkill2()
    {
        if (souls >= price)
        {
            if (canClick)
            {

            }
            else
            {
                canClick = true;
                ASkill_2();
                reload = reloaded;
                soul.UseSoul(price);
            }
        }


    }

    //public IEnumerator ASkill_2()
    public void ASkill_2()
    {
        timeon = true;

        if (timeon)
        {
            StartCoroutine(Blowing());
        }
        else
        {
            StopCoroutine(Blowing());
            
        }
    }

    IEnumerator Blowing()
    {
        
        Blow();
        yield return new WaitForSeconds(time);
    }

    public void Blow()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemies in enemy)
        {
            //enemies.transform.Translate(dir * speed * Time.deltaTime);
            enemies.GetComponent<Transform>().position = new Vector3(0, 0, 750);
            //enemies.GetComponent<Rigidbody>().position = new Vector3();

            //for (int i = 0; i < enemy.Length; i++)
            //{
                
            //}
        }
    }

    void Clicked(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, btn.colors.fadeDuration, true, true);
    }

}
