using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    [SerializeField] private Transform attackarea;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int danoGolpe;
    public int Daamage = 1;
    
 
   
    Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
       

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
                Golpe();
            
            anim.SetTrigger("Attack");

            

        }

        

        
    }

    
    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(attackarea.position, radioGolpe);
        foreach(Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemies"))
            {
                SoundManager.PlaySound("Punch");
                colisionador.transform.GetComponent<Health>().Damage(danoGolpe);
                
            }

            else if (colisionador.CompareTag("Boss"))
            {
                SoundManager.PlaySound("Punch");
                colisionador.transform.GetComponent<BossHealth>().DoDamage(0.5f);
            }

           else if (colisionador.CompareTag("Boss2"))
            {
                SoundManager.PlaySound("Punch");
                colisionador.transform.GetComponent<Health2Bar>().Damage(Daamage);
            }

            else if (colisionador.CompareTag("Robot"))
            {
                SoundManager.PlaySound("Punch");
                colisionador.transform.GetComponent<HealthRobot>().Damage(danoGolpe);
            }

            else if (colisionador.CompareTag("Boss3"))
            {
                SoundManager.PlaySound("Punch");
                colisionador.transform.GetComponent<HealthBoss3>().Damage(Daamage);
            } 
            
            else if (colisionador.CompareTag("FinalBoss"))
            {
                SoundManager.PlaySound("Punch");
                colisionador.transform.GetComponent<HealthBoss4>().Damage(Daamage);
            }
            







        }


    }

   

   
}
