using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_bot : MonoBehaviour
{
    private Transform player;
    private Transform bot;


    private bool facingRight = true;



    void Start()
    {
        
    }

    
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bot = GameObject.FindGameObjectWithTag("Enemy").transform;
        int x = Mathf.RoundToInt(player.position.x) - Mathf.RoundToInt(bot.position.x);

        if (facingRight == true && x < 0)
        {
            Flip();
        }
        else if (facingRight == false && x > 0)
        {
            Flip();
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

