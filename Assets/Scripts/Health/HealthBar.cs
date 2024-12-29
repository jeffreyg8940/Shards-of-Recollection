using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currenthealthBar; 

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.CurrentHealth / 100;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.CurrentHealth / 100;
    }
}
