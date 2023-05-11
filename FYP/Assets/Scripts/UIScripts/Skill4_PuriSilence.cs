using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Skill4_PuriSilence : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] Image cooldown;
    float reloaded = 10;
    float reload = 0;
    bool canClick = true;
    [SerializeField] int souls;
    [SerializeField] int price = 100; // (no
    Soul soul;

    public bool spawning;


    private void Start()
    {
        cooldown.fillAmount = 0;
        spawning = false;

        soul = FindObjectOfType<Soul>();

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
            if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4))
            {
                //EventSystem.current.SetSelectedGameObject(this.gameObject);
                ASkill4();
            }

            if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            {
                Clicked(btn.colors.pressedColor);
                //btn.onClick.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.Alpha4))
            {
                Clicked(btn.colors.normalColor);
            }
        }

    }

    public void ASkill4()
    {
        if (souls >= price)
        {
            if (canClick)
            {

            }
            else
            {
                canClick = true;
                spawning = true;
                reload = reloaded;
                soul.UseSoul(price);
            }
        }

    }

    void ASkill_4()
    {
        
        //area4.ToSkill4();
        //area4 = GetComponent<Skill4_Area>();
        //foreach(GameObject a in area4.allenemy)
        //{
        //    for(int i = 0; i < 3; i++)
        //    {
        //        Skill4_Area.Destroy(gameObject);
        //        Instantiate(angle);
        //, spawnpt.position, Quaternion.identity
        //    }
        //    }

        //gameObject.GetComponent<Skill4_Area>().ToSkill4();
        //area.enabled= true;

    }


    void Clicked(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, btn.colors.fadeDuration, true, true);
    }

}

