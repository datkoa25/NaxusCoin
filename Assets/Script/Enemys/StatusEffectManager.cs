using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private HealthPlayer health;
    public List<int> burnRickTimers = new List<int>();
    private void Start()
    {
        health = GetComponent<HealthPlayer>();
    }

    public void ApplyBurn(int ticks)
    {
        if(burnRickTimers.Count <= 0)
        {
            burnRickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnRickTimers.Add(ticks);
        }
    }

    public void ApplyHeal(int ticks)
    {
        if (burnRickTimers.Count <= 0)
        {
            burnRickTimers.Add(ticks);
            StartCoroutine(Heal());
        }
        else
        {
            burnRickTimers.Add(ticks);
        }
    }

    IEnumerator Burn()
    {
        while(burnRickTimers.Count > 0)
        {
            for(int i =0; i< burnRickTimers.Count; i++)
            {
                burnRickTimers[i]--;
            }

            health.TakeDamage(0.5f);
            burnRickTimers.RemoveAll(i => i == 0);

            yield return new WaitForSeconds(0.75f);
        }
    }

    IEnumerator Heal()
    {
        while (burnRickTimers.Count > 0)
        {
            for (int i = 0; i < burnRickTimers.Count; i++)
            {
                burnRickTimers[i]--;
            }

            health.AddHealth(1f);
            burnRickTimers.RemoveAll(i => i == 0);

            yield return new WaitForSeconds(1.5f);
        }
    }
}
