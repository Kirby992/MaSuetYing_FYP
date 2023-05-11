using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Skill1_Spawn : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] Image cooldown;
    float reloaded = 1;
    float reload = 0;
    bool canClick = true;
    [SerializeField] int souls;
    [SerializeField] int price = 10;
    Soul soul;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject asummon;


    private void Start()
    {
        cooldown.fillAmount= 0;

        soul = FindObjectOfType<Soul>();

        
    }

    void Cooling()
    {
        reload -= Time.deltaTime;

        if(reload < 0)
        {
            canClick= false;
            cooldown.fillAmount= 0;
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
            
            if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
            {
                ASkill1();
                
            }
            else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                Clicked(btn.colors.pressedColor);
                btn.onClick.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Alpha1))
            {
                Clicked(btn.colors.normalColor);
            }

        }
        else
        {
            //soul.NotEnough();
            //xgameObject.SetActive(false);
        }
    }
        

    public void ASkill1()
    {
        if (souls >= price)
        {
            if (canClick)
            {
                
            }
            else
            {
                canClick = true;
                Instantiate(asummon, spawnPoint.transform.position, spawnPoint.transform.rotation);
                reload = reloaded;
                soul.UseSoul(price);
            }
        }


    }

    void Clicked(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, btn.colors.fadeDuration, true, true);
    }

}

