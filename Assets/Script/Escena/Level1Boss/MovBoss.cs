using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBoss : MonoBehaviour
{
    public Rigidbody2D rbd2;
    public Transform jugador;
    private bool mirandoDerecha = true;
    Animator anim;
    public Transform shootPos;
    public float walkSpeed, tbwShots, shootSpeed;
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque; public GameObject bullet;





    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
       
        anim = GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance
            (transform.position, jugador.position);
        anim.SetFloat("distanciaJugador", distanciaJugador);
        
    }
    // Update is called once per frame
    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoDerecha)
            ||(jugador.position.x<transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            walkSpeed *= -1;
        }

     
}

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<HealthPlayer>().TakeDamage(1f);
                SoundManager.PlaySound("Melee");
            }
        }
    }

    public void SuperAttack()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<HealthPlayer>().TakeDamage(2f);
                SoundManager.PlaySound("Melee");
            }
        }
    }

    public void Sword()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<HealthPlayer>().TakeDamage(1f);
                SoundManager.PlaySound("Sword");
            }
        }
    }

    public void SuperSword()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<HealthPlayer>().TakeDamage(2.3f);
                SoundManager.PlaySound("Sword");
            }
        }
    }

   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);

    }

 
    public void Shoot()
    {
        SoundManager.PlaySound("Shoot");
        GameObject newBullet = Instantiate(bullet, shootPos.position,
            Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity =
            new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
    }
   
}
