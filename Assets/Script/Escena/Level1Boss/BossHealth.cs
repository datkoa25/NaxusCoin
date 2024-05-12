using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    Animator anim;
    private bool dead;
    Rigidbody2D rb2d;

    
    private void Awake()
    {
        currentHealth = startingHealth;
        rb2d = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();
    }
    public void DoDamage(float _dano)
    {
        currentHealth = Mathf.Clamp(currentHealth - _dano, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            Debug.Log("is being hurt");
        }

        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                SoundManager.PlaySound("Boss1y3");
               
               dead = true;
                StartCoroutine(Fall());
                StartCoroutine(Wait());
                BossUi.instance.Deactivator();

            }

        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Die();

    }

    private void Die()
    {
        Destroy(gameObject);
        
    }

}
