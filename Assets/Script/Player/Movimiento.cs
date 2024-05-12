using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movimiento : MonoBehaviour
{


    public Slider staminaBar;
    private float maxStamina = 100f;
    private float currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public static Movimiento instance;
    




    public bool isGrounded = false; 
    public bool isMoving = false; 
    public bool isRuning = false;
    public bool isFalling = false;
    public bool isLadder;
    public float usoStamina;






    public float Speed = 2f;  // velocidad de mi player si se mueve
   
    public float JumpForce = 3f; // fuerza de salto
    public float MovHor; // obtener el valor para el mov horizontal de mi player
    
    
    


    

    public LayerMask GroundLayer; // esto es para validar si mi player toca el suelo
    public float radius = 0.3f; // esto sirve para conocer si mi personaje esta tocando el piso
    public float GroundRayDist = 0.5f; // esto sirve para conocer si mi personaje esta tocando el piso

    private Rigidbody2D Rb;
    private Animator Anim;
    private SpriteRenderer Spr;


    //esta funcion se ejecuta antes que start

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Spr = GetComponent<SpriteRenderer>();

        FindObjectOfType<LadderMovement>();
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;



    }

    // Update is called once per frame
    void Update()
    {
       
        MovHor = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            Speed = 6f;
            isRuning = true;
            StaminaOnPress();
           if(currentStamina -  usoStamina < 0)
            {
                
                Speed = 2f;
            }
           
            else
            {
                Speed = 6f;
            }
            
        }

        else 
        {
            isRuning = false;
            if (currentStamina - usoStamina < 0)
            {
               
                Speed = 2f;
                
            }
            else
            {
                Speed = 4f;

            }


           
        }
       


        //validamos si mi personaje se esta moviendo
        isMoving = (MovHor != 0f);

        //varaiable = esta funcion traza un circulo y se proyecta hacia abajo y la distancia donde
        //se esta proyentando el circulo y se guarda en un capa
        // se debe crar un layer llamado Ground y lo asignamos
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, GroundRayDist, GroundLayer);

        //creamos el salto


       
        if (Input.GetKeyDown(KeyCode.Space ))
        {
            
            if (isGrounded)
            {
                if(currentStamina - usoStamina > 0f)
                {
                    UseStamina(5f);
                    Rb.velocity = Vector2.up * JumpForce;
                }

                else
                {
                    Rb.velocity = Vector2.up * 2f;
                }
                          
            }
            
        
               
        }

        if (Rb.velocity.y < 0 && !isLadder)
        {
            isFalling = true;
        }
        else if (Rb.velocity.y > 0)
        {
            isFalling = false;
        }
        if (isGrounded)
        {
            isFalling = false;
        }



        //Animator depues de configurar el animator ir aqui

        Anim.SetBool("IsMoving", isMoving);
        Anim.SetBool("IsGrounded", isGrounded);
        Anim.SetBool("IsRuning", isRuning);
        Anim.SetBool("IsFalling", isFalling);
        
        
        
        
        
      

        Flip(MovHor); 


        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }



    private void FixedUpdate()
    {
       

            Rb.velocity = new Vector2(MovHor * Speed, Rb.velocity.y); 

    }

   
   
    


    
    private void Flip(float _xFlip)
    {
        Vector3 flipPlayer = transform.localScale;
        if (_xFlip < 0)
        {
            flipPlayer.x = Mathf.Abs(flipPlayer.x) * -1;
        }
        else if (_xFlip > 0)
        {
            flipPlayer.x = Mathf.Abs(flipPlayer.x);
        }
        transform.localScale = flipPlayer;
    }

    public void UseStamina(float amount)
    {

        if (currentStamina - amount >= 0f)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }

        else
        {

            Debug.Log("Not enough energy");

        }
    }

    public void StaminaOnPress()
    {
        if (currentStamina - usoStamina >= 0f)
        {

            currentStamina -= usoStamina * Time.fixedDeltaTime;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }

        else
        {

            Debug.Log("Not enough energy");



        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;


        }

        regen = null;
    }
}


