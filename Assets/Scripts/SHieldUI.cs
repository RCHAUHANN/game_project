using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHieldUI : MonoBehaviour
{
    [SerializeField] RectTransform healthBar;
    float maxwidth;

    void Awake()
    {
        maxwidth = healthBar.rect.width;
    }

    private void OnEnable()
    {
        EventManager.onStartGame += ResetHealth;
        EventManager.onTakeDamage += updateSheildDisplay;
        
    }

    private void OnDisable() 
    {
        EventManager.onStartGame -= ResetHealth;
        EventManager.onTakeDamage -= updateSheildDisplay;
        
    }

    void updateSheildDisplay(float percentage)
    {
        healthBar.sizeDelta = new Vector2(maxwidth * percentage,0);

    }

    void ResetHealth()
    {
        healthBar.sizeDelta = new Vector2(maxwidth, 0);
    }
}
