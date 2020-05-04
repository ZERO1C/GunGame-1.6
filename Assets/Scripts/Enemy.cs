using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    // отдача
    private Transform player;
    private Transform bot;

    private Rigidbody2D rb;

    // Змінні прижка
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jump;

    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {




        
    }

    public void TakeDamage(int tolkanX, int tolkanY)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        int playerX = Mathf.RoundToInt(player.position.x);
        int playerY = Mathf.RoundToInt(player.position.y);

        bot = GameObject.FindGameObjectWithTag("Enemy").transform;
        int botX = Mathf.RoundToInt(bot.position.x);
        int botY = Mathf.RoundToInt(bot.position.y);

        int x = playerX - botX;
        int y = playerY - botY;

        if (x < 0)
        {
            if (y <= 0)
            {
                rb.velocity += Vector2.right * tolkanX;
                rb.velocity += Vector2.up * tolkanY;
            }
            if (y > 0)
            {
                rb.velocity += Vector2.right * tolkanX;
                rb.velocity += Vector2.down * tolkanY;
            }
        }
        if (x > 0)
        {
            if (y <= 0)
            {
                rb.velocity += Vector2.left * tolkanX;
                rb.velocity += Vector2.up * tolkanY;
            }
            if (y > 0)
            {
                rb.velocity += Vector2.left * tolkanX;
                rb.velocity += Vector2.down * tolkanY;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kordon"))
        {
            Destroy(gameObject);
        }
    }


    private void jump_triger()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jump;
            anim.SetTrigger("takeof");
        }
        if (isGrounded == true)
        {
            anim.SetBool("isjumping", false);
        }
        else
        {
            anim.SetBool("isjumping", true);
        }
    }
}
