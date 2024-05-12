using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBoss4 : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] private int health = 300;
    
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        HealthBar.value = health;
    }

    public void Damage(int attack)
    {
        health -= attack;
        if(health <= 150)
        {
            anim.SetBool("IsEnraged", true);
            
        }



        if (health < 0)
        {
            anim.SetTrigger("Die");
            StartCoroutine(Fall());
            StartCoroutine(Wait());
            SoundManager.PlaySound("Boss1y3");
            
           

        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(8f);
        Die();
        Creditos();
    }

   

    private void Die()
    {
        Destroy(gameObject);

    }

    public void Creditos()
    {
        SceneManager.LoadScene(6);
    }
}
