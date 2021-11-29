using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI healthText;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        setHpText(health);
    }
    public void setHealth(int health)
    {
        slider.value = health;

        //mencegah health negatif
        if (health < 0)
        {
            setHpText(0);
        }
        else
        {
            setHpText(health);
        }
    }

    void setHpText(int health)
    {
        healthText.text = health.ToString() + " HP";
    }
}
