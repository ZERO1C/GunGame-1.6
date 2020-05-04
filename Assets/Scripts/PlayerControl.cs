using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jump;
    private float MoveInput;
    
   
    private Rigidbody2D rb;

    // Змінні часу для отдачі
    private float timeBtwShots;
    public float startTimeBtwShots;
    private float time;
    public float startTime;
    // макс скорость
    public float maxspeedx;
    public float maxspeedy;


    // Змінна отдачі
    public float otdx;
    public float otdy;





    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity += new Vector2(MoveInput * speed, 0);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxspeedx, maxspeedx), Mathf.Clamp(rb.velocity.y, -maxspeedy, maxspeedy));

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float x = difference.x;
        float y = difference.y;

        if (MoveInput == 0)
        {
            anim.SetBool("isruning", false);
        }
        else
        {
            anim.SetBool("isruning", true);
        }
       

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                
                 
                
                    if (x > 0)
                    {
                        if(y>0)
                        {
                            rb.velocity += Vector2.left * otdx;
                            rb.velocity += Vector2.down * otdy;

                        }
                        if (y < 0)
                        {
                            rb.velocity += Vector2.left * otdx;
                            rb.velocity += Vector2.up * otdy;

                        }

                    
                    }
                        
                    if (x < 0)
                    {
                        if (y > 0)
                        {
                            rb.velocity += Vector2.right * otdx;
                            rb.velocity += Vector2.down * otdy;

                        }
                        if (y < 0)
                        {
                            rb.velocity += Vector2.right * otdx;
                            rb.velocity += Vector2.up * otdy;

                        }
                   
                    }
                    
                


                timeBtwShots = startTimeBtwShots;




            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }



    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jump;
            anim.SetTrigger("takeof");
        }
        if(isGrounded == true)
        {
            anim.SetBool("isjumping", false);
        }
        else
        {
            anim.SetBool("isjumping", true);
        }
        

        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Kordon")) 
        {
            Destroy(gameObject);
        }
    }

    

}
