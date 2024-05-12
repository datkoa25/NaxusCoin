using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health2Bar : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] private int health = 15;
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

        if(health <= 7)
        {
            anim.SetBool("IsEnraged", true);
        }

        if(health <= 0)
        {
            anim.SetTrigger("Die");
            StartCoroutine(Fall());
            StartCoroutine(Wait());
            SoundManager.PlaySound("Boss2");
            BossUi.instance.Deactivator();

        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.75f);
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
