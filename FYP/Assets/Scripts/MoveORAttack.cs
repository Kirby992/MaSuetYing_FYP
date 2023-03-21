using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MoveORAttack : MonoBehaviour
{
    [SerializeField] GameObject SkillBar;
    [SerializeField] GameObject AttackBar;
    bool attackBar = false;

    [SerializeField] Button btn;
    [SerializeField] Image cooldown;
    float reloaded = 5;
    float reload = 0;
    bool canClick = true;


    // Start is called before the first frame update
    void Start()
    {
        //cooldown.fillAmount = 0;
    }

    void Cooling()
    {
        reload -= Time.deltaTime;

        if (reload < 0)
        {
            canClick = false;
            //cooldown.fillAmount = 0;
        }
        else
        {
            //cooldown.fillAmount = reload / reloaded;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (canClick)
        {
            Cooling();
        }

        //change when mid fyp done HERE
        if (Input.GetKey(KeyCode.Z))
        {
            if (canClick)
            {

            }
            else
            {
                canClick = true;
                reload = reloaded;
            }

        }
        //TO HERE

        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
        {
            if(SkillBar == true)
            {
                SkillBar.SetActive(false);
                AttackBar.SetActive(true);
            }
            else
            {
                AttackBar.SetActive(false);
                SkillBar.SetActive(true);
            }
        }
    }

    public void MOVEorACK()
    {
        if(attackBar == false)
        {
            attackBar = true;

        }
        else
        {
            attackBar= false;

        }
    }

    public void AttackContro()
    {

    }

    public void MoveContro()
    {

    }




    public void ChangeButtonImage()
    {

    }

}
