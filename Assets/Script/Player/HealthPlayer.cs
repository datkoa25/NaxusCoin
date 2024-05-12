using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    [SerializeField] GameObject GameOver;
    public float currentHealth { get; private set; }
    Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
       if(currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            SoundManager.PlaySound("Damage");
        }

        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                SoundManager.PlaySound("Player");
                GetComponent<Movimiento>().enabled = false;
                GetComponent<Attack>().enabled = false;
                GetComponent<LadderMovement>().enabled = false;
                dead = true;
                StartCoroutine(Wait());
                StartCoroutine(Muerte());
                StartCoroutine(PausarSonidos());
                FindObjectOfType<SoundEffects>().GameOverSound();
            }
            
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    IEnumerator Muerte()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameOver.SetActive(true);
        
        

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject.GetComponent<Rigidbody2D>());
            
    }

    IEnumerator PausarSonidos()
    {
        yield return new WaitForSeconds(5.5f);
        Time.timeScale = 0f;
    }
   
}
