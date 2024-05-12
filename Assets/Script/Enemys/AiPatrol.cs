using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public float walkSpeed, range, tbwShots, shootSpeed;
    private float disToPlayer;
    [HideInInspector]
    public bool MustPatrol;

    private bool mustTurn, canShoot;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public Transform player, shootPos;
    public GameObject bullet;
    public Collider2D bodyCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        MustPatrol = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MustPatrol)
        {
            Patrol();
        }

        disToPlayer = Vector2.Distance(transform.position, player.position);

        if(disToPlayer<= range)
        {

            if(player.position.x > transform.position.x && 
                transform.localScale.x < 0 || player.position.x < transform.position.x 
                && transform.localScale.x > 0 )
            {
                Flip();

            }

            MustPatrol = false;
            rb.velocity = Vector2.zero;

            if (canShoot)
            
            StartCoroutine(Shoot());
        }
        else
        {
            MustPatrol = true;
        }
    }
    private void FixedUpdate()
    {
        if (MustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(enemyLayer))
        {
            Flip();
        }
        
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        MustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        MustPatrol = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(tbwShots);
        SoundManager.PlaySound("Shoot");
        GameObject newBullet = Instantiate(bullet,shootPos.position, 
            Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity =
            new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        canShoot = true;
    }
}
