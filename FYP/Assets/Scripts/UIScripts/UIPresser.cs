using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPresser : MonoBehaviour
{
    [SerializeField] Sprite m_image;
    [SerializeField] Sprite pressedImage;
    
    Image myimages;

    [SerializeField] GameObject aup;
    [SerializeField] GameObject adown;
    [SerializeField] GameObject aleft;
    [SerializeField] GameObject aright;

    bool upin = false;
    bool downin = false;
    bool leftin = false;
    bool rightin = false;

    float firstone = 0;


    bool InPress = false;


    // Start is called before the first frame update
    void Start()
    {
        myimages = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && upin == true)
        {

        }














        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
           Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
           Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
           Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            myimages.sprite = pressedImage;
        }
        else
        {
            myimages.sprite = m_image;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.UpArrow) && other.tag == "Up")
        {
            Destroy(other.gameObject);
            firstone++;
            Debug.Log("f1");
        }
        else
        {
            Destroy(other.gameObject);
        }

        if (Input.GetKey(KeyCode.DownArrow) && other.tag == "Down")
        {
            Destroy(other.gameObject);
            firstone++;
        }
        else
        {
            Destroy(other.gameObject);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && other.tag == "Left")
        {
            Destroy(other.gameObject);
            firstone++;
        }
        else
        {
            Destroy(other.gameObject);
        }

        if (Input.GetKey(KeyCode.RightArrow) && other.tag == "Right")
        {
            Destroy(other.gameObject);
            firstone++;
        }
        else
        {
            Destroy(other.gameObject);
        }



    }




}
