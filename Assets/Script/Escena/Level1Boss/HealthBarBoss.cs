using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private BossHealth bossHealth;
    void Start()
    {
        totalHealthBar.fillAmount = bossHealth.currentHealth / 10;
    }

   
    void Update()
    {
        currentHealthBar.fillAmount = bossHealth.currentHealth / 10;
    }
}
