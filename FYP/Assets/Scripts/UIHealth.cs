using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] Player healths;
    [SerializeField] Image fill;
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;


    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fill.enabled = false;
        }

        if (slider.value > slider.minValue && !fill.enabled)
        {
            fill.enabled = true;
        }

        float fillValue = healths.health / healths.maxHealth;
        if (fillValue <= slider.maxValue / 3)
        {
            fill.color = Color.red;
        }

        slider.value = fillValue;
    }
    
    void SetMaxHealth(float health)
    {
        slider.maxValue= health;
        slider.value= health;

        fill.color = gradient.Evaluate(1f);
    }
    
    void SetHealth(float health)
    {
        slider.value= health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
