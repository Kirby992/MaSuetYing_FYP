using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Soul : MonoBehaviour
{
    public static Soul instance;

    [SerializeField] TMP_Text soulnum;
    public int soul = 100;

    EnemyA1 EA1;
    EnemyA2 EA2;

    // Start is called before the first frame update
    void Start()
    {
        soulnum.text = soul.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //soulnum.text = soul.ToString();
    }

    public void GetSouls(int souls)
    {
        soul += souls;
        soulnum.text = soul.ToString();
    }

    public void UseSoul(int used)
    {
        soul -= used;
        soulnum.text = soul.ToString();
    }

    //public IEnumerable NotEnough()
    public void NotEnough()
    {
        //change font and color in few seconds
        //xsoulnum.fontSize = 60;
        //x?yield return new WaitForSeconds(1);
    }

}
