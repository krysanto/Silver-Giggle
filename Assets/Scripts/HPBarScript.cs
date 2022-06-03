using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color Medium;
    public Color High;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        Slider.maxValue = maxHealth;
        Slider.value = health;
        if (health / maxHealth > 0.5)
        {
            Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Medium, High, Slider.normalizedValue);
        }
        else
        {
            Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, Medium, Slider.normalizedValue);
        }
        
    }

    void Start()
    {
        Offset.y = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
