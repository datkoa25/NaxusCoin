using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 10;
    Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
       
        //anim.SetTrigger("Hurt");
        health -= amount;

        if(health <= 0)
        {
            Debug.Log("Muerto");
            SoundManager.PlaySound("NormalEnemies");
            Destroy(gameObject);
        }
       

      

    }
}
